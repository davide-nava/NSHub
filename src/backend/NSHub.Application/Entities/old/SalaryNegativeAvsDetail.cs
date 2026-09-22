using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryNegativeAvsDetail : BaseEntity
{
    public Guid SalaryNegativeAvsId { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public decimal ComputedValue { get; set; }

    public virtual SalaryNegativeAvs? SalaryNegativeAvs { get; set; }
}
