// <copyright file="Shipment.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a shipment.
/// </summary>
public class Shipment : AuditableTenantEntity
{
    /// <summary>
    /// Gets the shipment notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the courier identifier.
    /// </summary>
    public Guid CourierId { get; protected set; }

    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    public Guid UserId { get; protected set; }

    /// <summary>
    /// Gets the machine identifier.
    /// </summary>
    public Guid? MachineId { get; protected set; }

    /// <summary>
    /// Gets the customer identifier.
    /// </summary>
    public Guid CustomerId { get; protected set; }

    /// <summary>
    /// Gets the shipment creation date.
    /// </summary>
    public DateTime Date { get; protected set; }

    /// <summary>
    /// Gets the shipment arrival date.
    /// </summary>
    public DateTime ArrivalDate { get; protected set; }

    /// <summary>
    /// Gets the shipment dispatch date.
    /// </summary>
    public DateTime SendDate { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the shipment is closed.
    /// </summary>
    public bool IsClosed { get; protected set; }

    /// <summary>
    /// Gets the associated courier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Courier? Courier { get; protected set; }

    /// <summary>
    /// Gets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; protected set; }

    /// <summary>
    /// Gets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; protected set; }

    /// <summary>
    /// Gets the user responsible for the shipment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual User? User { get; protected set; }

    /// <summary>
    /// Gets the articles associated with this shipment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<ShipmentArticle> ShipmentArticles { get; protected set; }
        = new List<ShipmentArticle>();

    /// <summary>
    /// Gets the tickets associated with this shipment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketShipment> TicketShipments { get; protected set; }
        = new List<TicketShipment>();
}
