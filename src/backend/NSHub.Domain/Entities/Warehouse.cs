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
    /// Gets the responsible person identifier.
    /// </summary>
    public Guid PersonId { get; protected set; }

    /// <summary>
    /// Gets the address identifier.
    /// </summary>
    public Guid AddressId { get; protected set; }

    /// <summary>
    /// Gets the warehouse description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets a value indicating whether the warehouse is external.
    /// </summary>
    public bool? IsExternal { get; protected set; }

    /// <summary>
    /// Gets the opening time.
    /// </summary>
    public string? OpeningTime { get; protected set; }

    /// <summary>
    /// Gets the closing time.
    /// </summary>
    public string? ClosingTime { get; protected set; }

    /// <summary>
    /// Gets the warehouse name.
    /// </summary>
    public string? Name { get; protected set; }

    /// <summary>
    /// Gets the warehouse notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the warehouse address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? Address { get; protected set; }

    /// <summary>
    /// Gets the responsible person.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Person? Person { get; protected set; }

    /// <summary>
    /// Gets the articles stored in this warehouse.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> Articles { get; protected set; }
        = new List<Article>();

    /// <summary>
    /// Gets the organization associations for this warehouse.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<WarehouseOrganization> WarehouseOrganizations { get; protected set; }
        = new List<WarehouseOrganization>();
}
