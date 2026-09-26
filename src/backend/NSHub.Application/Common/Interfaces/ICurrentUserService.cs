// <copyright file="ICurrentUserService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;

namespace NSHub.Application.Common.Interfaces;

/// <summary>
/// Abstraction for accessing authenticated user claims and context.
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets the unique identifier of the authenticated user.
    /// </summary>
    Guid? UserId { get; }

    /// <summary>
    /// Gets the unique identifier of the current tenant.
    /// </summary>
    Guid? TenantId { get; }

    /// <summary>
    /// Gets a value indicating whether the current user is authenticated.
    /// </summary>
    bool IsAuthenticated { get; }

    /// <summary>
    /// Gets the email address of the authenticated user.
    /// </summary>
    string? Email { get; }

    /// <summary>
    /// Gets the role of the authenticated user.
    /// </summary>
    string? Role { get; }

    /// <summary>
    /// Gets the preferred language of the current user.
    /// </summary>
    string PreferredLanguage { get; }
}
