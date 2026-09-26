// <copyright file="WarehouseOrganization.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents the association between a warehouse and an organization.
/// </summary>
public class WarehouseOrganization : AuditableTenantEntity
{
    /// <summary>
    /// Gets the warehouse identifier.
    /// </summary>
    public Guid WarehouseId { get; protected set; }

    /// <summary>
    /// Gets the organization identifier.
    /// </summary>
    public Guid OrganizationId { get; protected set; }

    /// <summary>
    /// Gets the associated organization.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Organization? Organization { get; protected set; }

    /// <summary>
    /// Gets the associated warehouse.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Warehouse? Warehouse { get; protected set; }
}
