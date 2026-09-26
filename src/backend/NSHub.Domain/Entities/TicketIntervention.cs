using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class TicketIntervention : AuditableTenantEntity
{
    public Guid InterventionId { get; protected set; }
    public Guid TicketId { get; protected set; }
    public DateTime Date { get; protected set; }
    public string? Notes { get; protected set; }
    public virtual Intervention? Intervention { get; protected set; }
    public virtual Ticket? Ticket { get; protected set; }

    protected TicketIntervention() { }

    public static TicketIntervention Create()
    {
        return new TicketIntervention();
    }
}
