using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryNegativeAv : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public Guid InsuranceId { get; set; }

    public int ComputingYear { get; set; }

    public decimal ComputedValue { get; set; }

    public DateTime ExpectedDate { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Insurance? Insurance { get; set; }

}
