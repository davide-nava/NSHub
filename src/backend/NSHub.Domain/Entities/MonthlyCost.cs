// <copyright file="MonthlyCost.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

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
