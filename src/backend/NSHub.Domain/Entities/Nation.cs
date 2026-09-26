// <copyright file="Nation.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a nation.
/// </summary>
public class Nation : AuditableTenantEntity
{
    /// <summary>
    /// Gets the nation code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the nation name.
    /// </summary>
    public string? Name { get; protected set; }

    /// <summary>
    /// Gets the addresses associated with this nation.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Address> Addresses { get; protected set; }
        = new List<Address>();
}
