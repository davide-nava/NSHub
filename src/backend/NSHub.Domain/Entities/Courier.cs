// <copyright file="Courier.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a courier.
/// </summary>
public class Courier : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the address identifier.
    /// </summary>
    public Guid? AddressId { get; set; }

    /// <summary>
    /// Gets or sets the contact identifier.
    /// </summary>
    public Guid? ContactId { get; set; }

    /// <summary>
    /// Gets or sets the courier name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the courier address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? Address { get; set; }

    /// <summary>
    /// Gets or sets the shipments associated with this courier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Shipment> Shipments { get; set; }
        = [];
}
