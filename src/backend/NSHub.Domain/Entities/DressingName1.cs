using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class DressingName1 : AuditableTenantEntity
{
    public Guid LanguageId { get; protected set; }
    public string Pos { get; protected set; } = string.Empty;
    public string Pos2 { get; protected set; } = string.Empty;
    public string Pos3 { get; protected set; } = string.Empty;
    public string Cycle1 { get; protected set; } = string.Empty;
    public string Cycle2 { get; protected set; } = string.Empty;
    public string Cycle3 { get; protected set; } = string.Empty;
    public string OilOff { get; protected set; } = string.Empty;
    public string OilInt { get; protected set; } = string.Empty;
    public string OilOn { get; protected set; } = string.Empty;

    protected DressingName1() { }

    public static DressingName1 Create()
    {
        return new DressingName1();
    }
}
