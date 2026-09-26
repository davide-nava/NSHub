using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class TicketShipment : AuditableTenantEntity
{
    public DateTime Date { get; protected set; }
    public Guid ShipmentId { get; protected set; }
    public Guid TicketId { get; protected set; }
    public string? Notes { get; protected set; }
    public virtual Shipment? Shipment { get; protected set; }
    public virtual Ticket? Ticket { get; protected set; }

    protected TicketShipment() { }

    public static TicketShipment Create()
    {
        return new TicketShipment();
    }
}
