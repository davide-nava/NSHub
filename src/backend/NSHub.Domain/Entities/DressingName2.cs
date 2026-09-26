// <copyright file="DressingName2.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class DressingName2 : AuditableTenantEntity
{
    public Guid LanguageId { get; protected set; }
    public string Retreat { get; protected set; } = string.Empty;
    public string Chip { get; protected set; } = string.Empty;
    public string Ancl { get; protected set; } = string.Empty;
    public string AllInt { get; protected set; } = string.Empty;
    public string AllExt { get; protected set; } = string.Empty;
    public string OutVel { get; protected set; } = string.Empty;
    public string Vel { get; protected set; } = string.Empty;
    public string Removal { get; protected set; } = string.Empty;
    public string Cycle2 { get; protected set; } = string.Empty;
    public string Cycle3 { get; protected set; } = string.Empty;

    protected DressingName2() { }

    public static DressingName2 Create()
    {
        return new DressingName2();
    }
}
