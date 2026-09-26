using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class SystemBootMessage : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    protected SystemBootMessage() { }

    public static SystemBootMessage Create()
    {
        return new SystemBootMessage();
    }
}
