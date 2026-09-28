// <copyright file="ICurrentUserService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Common.Interfaces;

/// <summary>
/// Abstraction for accessing authenticated user claims and context.
/// </summary>
public interface ICurrentUserService
{
    /// <summary>
    /// Gets or sets the unique identifier of the authenticated user.
    /// </summary>
    public Guid? UserId { get; }

    /// <summary>
    /// Gets or sets the unique identifier of the current tenant.
    /// </summary>
    public Guid? TenantId { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the current user is authenticated.
    /// </summary>
    public bool IsAuthenticated { get; }

    /// <summary>
    /// Gets or sets the email address of the authenticated user.
    /// </summary>
    public string? Email { get; }

    /// <summary>
    /// Gets or sets the role of the authenticated user.
    /// </summary>
    public string? Role { get; }

    /// <summary>
    /// Gets or sets the preferred language of the current user.
    /// </summary>
    public string PreferredLanguage { get; }
}
