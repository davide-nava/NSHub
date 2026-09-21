// <copyright file="AuthenticateUserCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Identity.Commands.AuthenticateUser;

using MediatR;
using NSHub.Application.Identity.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Command to authenticate an enterprise user with credentials.
/// </summary>
public sealed record AuthenticateUserCommand(
    string Email,
    string Password) : IRequest<Result<AuthenticationResultDto>>;
