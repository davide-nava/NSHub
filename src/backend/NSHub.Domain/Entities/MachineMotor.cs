using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MachineMotor : AuditableTenantEntity
{
    public string Axis { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;

    protected MachineMotor() { }

    public static MachineMotor Create()
    {
        return new MachineMotor();
    }
}
