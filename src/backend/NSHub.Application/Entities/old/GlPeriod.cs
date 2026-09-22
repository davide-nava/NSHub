using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class GlPeriod : BaseEntity
{
    public int GlPeriodId { get; set; }

    public int CompanyId { get; set; }

    public string PeriodCode { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public bool IsOpen { get; set; }

    public virtual Company Company { get; set; } = null!;
}
