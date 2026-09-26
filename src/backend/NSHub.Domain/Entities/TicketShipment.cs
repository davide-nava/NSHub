// <copyright file="TicketShipment.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents the association between a ticket and a shipment.
/// </summary>
public class TicketShipment : AuditableTenantEntity
{
    /// <summary>
    /// Gets the shipment date.
    /// </summary>
    public DateTime Date { get; protected set; }

    /// <summary>
    /// Gets the shipment identifier.
    /// </summary>
    public Guid ShipmentId { get; protected set; }

    /// <summary>
    /// Gets the ticket identifier.
    /// </summary>
    public Guid TicketId { get; protected set; }

    /// <summary>
    /// Gets the shipment notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the associated shipment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Shipment? Shipment { get; protected set; }

    /// <summary>
    /// Gets the associated ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Ticket? Ticket { get; protected set; }
}
