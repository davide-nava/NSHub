using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Setting : AuditableTenantEntity
{
    public string Key { get; protected set; } = string.Empty;
    public string? Value { get; protected set; }
    public string Group { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    protected Setting() { }

    public static Setting Create()
    {
        return new Setting();
    }
}
