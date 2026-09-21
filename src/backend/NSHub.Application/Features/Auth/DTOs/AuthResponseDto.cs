// <copyright file="AuthResponseDto.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Enums;

namespace NSHub.Application.Features.Auth.DTOs;

/// <summary>
/// Authentication response containing the JWT bearer token and employee profile details.
/// </summary>
public record AuthResponseDto(
    string Token,
    Guid EmployeeId,
    string FullName,
    string Email,
    string Role,
    LanguageCode PreferredLanguage,
    Oll1Regime Oll1Regime
);
