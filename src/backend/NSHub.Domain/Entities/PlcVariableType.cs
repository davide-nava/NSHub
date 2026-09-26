using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class PlcVariableType : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;

    private readonly List<PlcVariable> _plcVariables = new();
    public virtual IReadOnlyCollection<PlcVariable> PlcVariables => _plcVariables.AsReadOnly();

    protected PlcVariableType() { }

    public static PlcVariableType Create()
    {
        return new PlcVariableType();
    }
}
