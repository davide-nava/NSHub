// <copyright file="GetUserByIdQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Identity.Queries.GetUserById;

using MediatR;
using NSHub.Application.Identity.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Identity.Repositories;
using NSHub.Domain.Identity.ValueObjects;

/// <summary>
/// Handler for retrieving user profile details by identifier.
/// </summary>
public sealed class GetUserByIdQueryHandler(IUserRepository userRepository) : IRequestHandler<GetUserByIdQuery, Result<UserDto>>
{
    public async Task<Result<UserDto>> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
    {
        var user = await userRepository.GetByIdAsync(new UserId(request.Id), cancellationToken);
        if (user is null)
        {
            return Result<UserDto>.Failure(Error.NotFound("User.NotFound", $"User with ID '{request.Id}' was not found."));
        }

        var dto = new UserDto(
            user.Id.Value,
            user.Email,
            user.FirstName,
            user.LastName,
            user.Status.ToString(),
            user.Roles.Select(r => r.RoleId.ToString()).ToList());

        return Result<UserDto>.Success(dto);
    }
}
