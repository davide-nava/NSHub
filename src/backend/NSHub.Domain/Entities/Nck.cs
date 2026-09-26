using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Nck : AuditableTenantEntity
{
    public string Config { get; protected set; } = string.Empty;
    public string State { get; protected set; } = string.Empty;
    public string Affair { get; protected set; } = string.Empty;
    public string StateEnh { get; protected set; } = string.Empty;
    public string FbName { get; protected set; } = string.Empty;
    public string Version { get; protected set; } = string.Empty;

    protected Nck() { }

    public static Nck Create()
    {
        return new Nck();
    }
}
