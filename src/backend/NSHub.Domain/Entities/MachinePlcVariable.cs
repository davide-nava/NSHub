using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MachinePlcVariable : AuditableTenantEntity
{
    public Guid PlcVariableId { get; protected set; }
    public string? Name { get; protected set; }
    public string? Value { get; protected set; }
    public string? MachineNumber { get; protected set; }
    public DateTime Date { get; protected set; }
    public string? Program { get; protected set; }
    public virtual PlcVariable? PlcVariable { get; protected set; }

    protected MachinePlcVariable() { }

    public static MachinePlcVariable Create()
    {
        return new MachinePlcVariable();
    }
}
