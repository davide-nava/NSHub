// <copyright file="Dressing1.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Dressing1 : AuditableTenantEntity
{
    public decimal X { get; protected set; }
    public decimal Y { get; protected set; }
    public decimal Z { get; protected set; }
    public decimal V { get; protected set; }
    public decimal W { get; protected set; }
    public bool IsPos1 { get; protected set; }
    public bool IsPos2 { get; protected set; }
    public bool IsPos3 { get; protected set; }
    public bool IsCycle1 { get; protected set; }
    public bool IsCycle2 { get; protected set; }
    public bool IsCycle3 { get; protected set; }
    public bool IsOilOff { get; protected set; }
    public bool IsOilnt { get; protected set; }
    public bool IsOilOn { get; protected set; }

    protected Dressing1() { }

    public static Dressing1 Create()
    {
        return new Dressing1();
    }
}
