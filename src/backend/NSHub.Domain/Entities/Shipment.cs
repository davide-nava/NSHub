using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Shipment : AuditableTenantEntity
{
    public string? Notes { get; protected set; }
    public Guid CourierId { get; protected set; }
    public Guid UserId { get; protected set; }
    public Guid? MachineId { get; protected set; }
    public Guid CustomerId { get; protected set; }
    public DateTime Date { get; protected set; }
    public DateTime ArrivalDate { get; protected set; }
    public DateTime SendDate { get; protected set; }
    public bool IsClosed { get; protected set; }
    public virtual Courier? Courier { get; protected set; }
    public virtual Customer? Customer { get; protected set; }
    public virtual Machine? Machine { get; protected set; }
    public virtual User? User { get; protected set; }

    private readonly List<ShipmentArticle> _shipmentArticles = new();
    public virtual IReadOnlyCollection<ShipmentArticle> ShipmentArticles => _shipmentArticles.AsReadOnly();
    private readonly List<TicketShipment> _ticketShipments = new();
    public virtual IReadOnlyCollection<TicketShipment> TicketShipments => _ticketShipments.AsReadOnly();

    protected Shipment() { }

    public static Shipment Create()
    {
        return new Shipment();
    }
}
