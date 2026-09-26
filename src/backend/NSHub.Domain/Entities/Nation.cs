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
    /// Gets or sets the nation code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the nation name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the addresses associated with this nation.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Address> Addresses { get; set; }
        = [];
}
