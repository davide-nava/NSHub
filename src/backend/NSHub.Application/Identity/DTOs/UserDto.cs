// <copyright file="UserDto.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Identity.DTOs;

/// <summary>
/// Data transfer object representing an enterprise user.
/// </summary>
public sealed record UserDto(
    Guid Id,
    string Email,
    string FirstName,
    string LastName,
    string Status,
    IReadOnlyList<string> Roles);
