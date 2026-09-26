using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class TicketStatus : AuditableTenantEntity
{
    public Guid TicketId { get; protected set; }
    public Guid MachineId { get; protected set; }
    public Guid UserId { get; protected set; }
    public Guid TicketStatusTypeId { get; protected set; }
    public DateTime Date { get; protected set; }
    public string? Notes { get; protected set; }
    public virtual Machine? Machine { get; protected set; }
    public virtual Ticket? Ticket { get; protected set; }
    public virtual TicketStatusType? TicketStatusType { get; protected set; }
    public virtual User? User { get; protected set; }

    protected TicketStatus() { }

    public static TicketStatus Create()
    {
        return new TicketStatus();
    }
}
