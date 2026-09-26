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
    /// Gets or sets the shipment notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the courier identifier.
    /// </summary>
    public Guid CourierId { get; set; }

    /// <summary>
    /// Gets or sets the user identifier.
    /// </summary>
    public Guid UserId { get; set; }

    /// <summary>
    /// Gets or sets the machine identifier.
    /// </summary>
    public Guid? MachineId { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier.
    /// </summary>
    public Guid CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the shipment creation date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the shipment arrival date.
    /// </summary>
    public DateTime ArrivalDate { get; set; }

    /// <summary>
    /// Gets or sets the shipment dispatch date.
    /// </summary>
    public DateTime SendDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the shipment is closed.
    /// </summary>
    public bool IsClosed { get; set; }

    /// <summary>
    /// Gets or sets the associated courier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Courier? Courier { get; set; }

    /// <summary>
    /// Gets or sets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; set; }

    /// <summary>
    /// Gets or sets the associated machine.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Machine? Machine { get; set; }

    /// <summary>
    /// Gets or sets the user responsible for the shipment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual User? User { get; set; }

    /// <summary>
    /// Gets or sets the articles associated with this shipment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<ShipmentArticle> ShipmentArticles { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the tickets associated with this shipment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<TicketShipment> TicketShipments { get; set; }
        = [];
}
