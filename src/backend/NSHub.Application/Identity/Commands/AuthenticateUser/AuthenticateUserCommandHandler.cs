// <copyright file="AuthenticateUserCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Identity.Commands.AuthenticateUser;

using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Identity.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Identity.Enums;
using NSHub.Domain.Identity.Repositories;
using NSHub.Domain.Identity.Services;

/// <summary>
/// Handler for authenticating users and issuing JWT security tokens.
/// </summary>
public sealed class AuthenticateUserCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IJwtTokenService jwtTokenService,
    IUnitOfWork unitOfWork) : IRequestHandler<AuthenticateUserCommand, Result<AuthenticationResultDto>>
{
    private const int MaxFailedAttempts = 5;
    private static readonly TimeSpan LockoutDuration = TimeSpan.FromMinutes(15);

    public async Task<Result<AuthenticationResultDto>> Handle(AuthenticateUserCommand request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (user is null)
        {
            return Result<AuthenticationResultDto>.Failure(Error.Unauthorized("Auth.InvalidCredentials", "Invalid email or password."));
        }

        if (user.Status == UserStatus.LockedOut)
        {
            if (user.LockoutEndUtc.HasValue && user.LockoutEndUtc.Value > DateTime.UtcNow)
            {
                return Result<AuthenticationResultDto>.Failure(Error.Forbidden("Auth.AccountLocked", "User account is locked due to consecutive failed attempts."));
            }

            user.Unlock();
        }

        if (user.Status != UserStatus.Active)
        {
            return Result<AuthenticationResultDto>.Failure(Error.Forbidden("Auth.AccountInactive", "User account is not active."));
        }

        var isPasswordValid = passwordHasher.VerifyPassword(request.Password, user.PasswordHash, user.PasswordSalt);
        if (!isPasswordValid)
        {
            user.RecordFailedLoginAttempt(MaxFailedAttempts, LockoutDuration);
            userRepository.Update(user);
            _ = await unitOfWork.SaveChangesAsync(cancellationToken);
            return Result<AuthenticationResultDto>.Failure(Error.Unauthorized("Auth.InvalidCredentials", "Invalid email or password."));
        }

        user.RecordSuccessfulLogin();
        userRepository.Update(user);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        var roles = user.Roles.Select(r => r.RoleId.ToString()).ToList();
        var token = jwtTokenService.GenerateUserToken(user, roles);
        var expiresAtUtc = DateTime.UtcNow.AddDays(7);

        var userDto = new UserDto(
            user.Id.Value,
            user.Email,
            user.FirstName,
            user.LastName,
            user.Status.ToString(),
            roles);

        return Result<AuthenticationResultDto>.Success(new AuthenticationResultDto(token, userDto, expiresAtUtc));
    }
}
