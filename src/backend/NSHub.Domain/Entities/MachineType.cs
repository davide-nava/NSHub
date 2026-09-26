using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MachineType : AuditableTenantEntity
{
    public string Number { get; protected set; } = string.Empty;
    public string? Image { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public DateTime Date { get; protected set; }
    public int Axes { get; protected set; }
    public int Spindles { get; protected set; }
    public string? Cnc { get; protected set; }
    public string? Specialty { get; protected set; }
    public string? Details { get; protected set; }

    private readonly List<Machine> _machines = new();
    public virtual IReadOnlyCollection<Machine> Machines => _machines.AsReadOnly();

    protected MachineType() { }

    public static MachineType Create()
    {
        return new MachineType();
    }
}
