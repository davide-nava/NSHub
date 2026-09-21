// <copyright file="AuthenticationResultDto.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Identity.DTOs;

/// <summary>
/// Data transfer object representing the result of a successful authentication.
/// </summary>
public sealed record AuthenticationResultDto(
    string Token,
    UserDto User,
    DateTime ExpiresAtUtc);
