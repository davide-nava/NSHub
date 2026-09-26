using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class PlcType : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;

    private readonly List<Machine> _machines = new();
    public virtual IReadOnlyCollection<Machine> Machines => _machines.AsReadOnly();

    protected PlcType() { }

    public static PlcType Create()
    {
        return new PlcType();
    }
}
