using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MachineAxisEncoder : AuditableTenantEntity
{
    public string Axis { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;

    protected MachineAxisEncoder() { }

    public static MachineAxisEncoder Create()
    {
        return new MachineAxisEncoder();
    }
}
