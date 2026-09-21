// <copyright file="ICurrentUserService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Common.Interfaces;

/// <summary>
/// Abstraction for accessing authenticated user claims and context.
/// </summary>
public interface ICurrentUserService
{
    Guid? UserId { get; }
    string? Email { get; }
    string? Role { get; }
    string PreferredLanguage { get; }
}
