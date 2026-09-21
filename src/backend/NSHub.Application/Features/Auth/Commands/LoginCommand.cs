// <copyright file="LoginCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Features.Auth.DTOs;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.Auth.Commands;

/// <summary>
/// Command to authenticate an employee with email and password credentials.
/// </summary>
public record LoginCommand(string Email, string Password) : IRequest<Result<AuthResponseDto>>;
