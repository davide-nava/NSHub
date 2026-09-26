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
    /// Gets the address identifier.
    /// </summary>
    public Guid? AddressId { get; protected set; }

    /// <summary>
    /// Gets the contact identifier.
    /// </summary>
    public Guid? ContactId { get; protected set; }

    /// <summary>
    /// Gets the courier name.
    /// </summary>
    public string? Name { get; protected set; }

    /// <summary>
    /// Gets additional notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the courier address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? Address { get; protected set; }

    /// <summary>
    /// Gets the shipments associated with this courier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Shipment> Shipments { get; protected set; }
        = new List<Shipment>();
}
