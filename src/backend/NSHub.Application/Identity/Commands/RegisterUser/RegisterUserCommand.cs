// <copyright file="RegisterUserCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Identity.Commands.RegisterUser;

using MediatR;
using NSHub.Application.Identity.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Command to register a new enterprise user.
/// </summary>
public sealed record RegisterUserCommand(
    string Email,
    string Password,
    string FirstName,
    string LastName) : IRequest<Result<UserDto>>;
