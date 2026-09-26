// <copyright file="User.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.AspNetCore.Identity;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an application user.
/// </summary>
public class User : AuditableEntity
{
    /// <summary>
    /// Gets the current tenant identifier.
    /// </summary>
    public Guid? CurrentTenantId { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the user is active.
    /// </summary>
    public bool IsActive { get; protected set; }

    /// <summary>
    /// Gets the ASP.NET Identity user identifier.
    /// </summary>
    public string? AspNetUserId { get; protected set; }

    /// <summary>
    /// Gets the user email address.
    /// </summary>
    public string? Email { get; protected set; }

    /// <summary>
    /// Gets the associated ASP.NET Identity user.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual IdentityUser? AspNetUser { get; protected set; }

    /// <summary>
    /// Gets the user's current tenant.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Tenant? CurrentTenant { get; protected set; }
}
