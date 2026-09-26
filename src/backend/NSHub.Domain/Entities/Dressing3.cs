using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Dressing3 : AuditableTenantEntity
{
    public bool IsHfSpindle { get; protected set; }
    public bool IsNormalSpindle { get; protected set; }
    public decimal WorkSpeed { get; protected set; }
    public decimal HfSpeed { get; protected set; }
    public decimal NormalSpeed { get; protected set; }

    protected Dressing3() { }

    public static Dressing3 Create()
    {
        return new Dressing3();
    }
}
