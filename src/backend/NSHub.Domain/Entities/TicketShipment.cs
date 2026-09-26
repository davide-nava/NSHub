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
    /// Gets or sets the shipment date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the shipment identifier.
    /// </summary>
    public Guid ShipmentId { get; set; }

    /// <summary>
    /// Gets or sets the ticket identifier.
    /// </summary>
    public Guid TicketId { get; set; }

    /// <summary>
    /// Gets or sets the shipment notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the associated shipment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Shipment? Shipment { get; set; }

    /// <summary>
    /// Gets or sets the associated ticket.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Ticket? Ticket { get; set; }
}
