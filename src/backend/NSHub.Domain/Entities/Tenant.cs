// <copyright file="Tenant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a tenant.
/// </summary>
public class Tenant : AuditableEntity
{
    /// <summary>
    /// Gets the tenant description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the tenant name.
    /// </summary>
    public string Name { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets a value indicating whether the tenant is active.
    /// </summary>
    public bool IsActive { get; protected set; }

    /// <summary>
    /// Gets the users associated with this tenant.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<User> Users { get; protected set; }
        = new List<User>();
}
