using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MachineEvent : AuditableTenantEntity
{
    public string? Notes { get; protected set; }
    public Guid MachineEventTypeId { get; protected set; }
    public Guid MachineId { get; protected set; }
    public DateTime Date { get; protected set; }
    public virtual Machine? Machine { get; protected set; }
    public virtual MachineEventType? MachineEventType { get; protected set; }

    protected MachineEvent() { }

    public static MachineEvent Create()
    {
        return new MachineEvent();
    }
}
