// <copyright file="Dressing2.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Dressing2 : AuditableTenantEntity
{
    public decimal Retraction { get; protected set; }
    public decimal Chip { get; protected set; }
    public decimal Chip2 { get; protected set; }
    public decimal Chip3 { get; protected set; }
    public decimal Ancl { get; protected set; }
    public decimal AllInt { get; protected set; }
    public decimal AllExt { get; protected set; }
    public decimal WorkAdv { get; protected set; }
    public decimal ExtAxVel { get; protected set; }
    public decimal ExtAxVel2 { get; protected set; }
    public decimal ExtAxVel3 { get; protected set; }
    public decimal Removal { get; protected set; }
    public decimal Removal2 { get; protected set; }
    public decimal Removal3 { get; protected set; }
    public bool IsCycle2 { get; protected set; }
    public bool IsCycle3 { get; protected set; }

    protected Dressing2() { }

    public static Dressing2 Create()
    {
        return new Dressing2();
    }
}
