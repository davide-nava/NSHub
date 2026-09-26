using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class MonthlyCost : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;
    public decimal? Amount { get; protected set; }
    public DateTime? StartDate { get; protected set; }
    public DateTime? EndDate { get; protected set; }

    protected MonthlyCost() { }

    public static MonthlyCost Create()
    {
        return new MonthlyCost();
    }
}
