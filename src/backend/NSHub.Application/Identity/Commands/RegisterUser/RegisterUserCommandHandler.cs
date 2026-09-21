// <copyright file="RegisterUserCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Identity.Commands.RegisterUser;

using MediatR;
using NSHub.Application.Identity.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Identity.Entities;
using NSHub.Domain.Identity.Repositories;
using NSHub.Domain.Identity.Services;
using NSHub.Domain.Identity.ValueObjects;

/// <summary>
/// Handler for processing <see cref="RegisterUserCommand"/>.
/// </summary>
public sealed class RegisterUserCommandHandler(
    IUserRepository userRepository,
    IPasswordHasher passwordHasher,
    IUnitOfWork unitOfWork) : IRequestHandler<RegisterUserCommand, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
    {
        if (await userRepository.ExistsByEmailAsync(request.Email, cancellationToken))
        {
            return Result<UserDto>.Failure(Error.Conflict("User.EmailExists", "A user with the specified email already exists."));
        }

        var (hash, salt) = passwordHasher.HashPassword(request.Password);
        var user = new User(
            UserId.New(),
            request.Email,
            hash,
            salt,
            request.FirstName,
            request.LastName);

        await userRepository.AddAsync(user, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        var dto = new UserDto(
            user.Id.Value,
            user.Email,
            user.FirstName,
            user.LastName,
            user.Status.ToString(),
            []);

        return Result<UserDto>.Success(dto);
    }
}
