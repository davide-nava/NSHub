using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MachineMechanicalAssembly : AuditableTenantEntity
{
    public string Ref { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;

    protected MachineMechanicalAssembly() { }

    public static MachineMechanicalAssembly Create()
    {
        return new MachineMechanicalAssembly();
    }
}
