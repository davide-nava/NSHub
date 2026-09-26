// <copyright file="Warehouse.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a warehouse.
/// </summary>
public class Warehouse : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the responsible person identifier.
    /// </summary>
    public Guid PersonId { get; set; }

    /// <summary>
    /// Gets or sets the address identifier.
    /// </summary>
    public Guid AddressId { get; set; }

    /// <summary>
    /// Gets or sets the warehouse description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the warehouse is external.
    /// </summary>
    public bool? IsExternal { get; set; }

    /// <summary>
    /// Gets or sets the opening time.
    /// </summary>
    public string? OpeningTime { get; set; }

    /// <summary>
    /// Gets or sets the closing time.
    /// </summary>
    public string? ClosingTime { get; set; }

    /// <summary>
    /// Gets or sets the warehouse name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the warehouse notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the warehouse address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? Address { get; set; }

    /// <summary>
    /// Gets or sets the responsible person.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Person? Person { get; set; }

    /// <summary>
    /// Gets or sets the articles stored in this warehouse.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> Articles { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the organization associations for this warehouse.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<WarehouseOrganization> WarehouseOrganizations { get; set; }
        = [];
}
