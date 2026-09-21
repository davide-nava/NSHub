using System;
using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryInsuranceLpp : BaseEntity
{
    public Guid SalaryInsuranceNameId { get; set; }

    public DateTime ValidFrom { get; set; }

    public string InsuranceNumber { get; set; } = null!;

    public string CustomerNumber { get; set; } = null!;

    public string ContractNumber { get; set; } = null!;

    public decimal MaxAvsSalary { get; set; }

    public decimal CoordinationFee { get; set; }

    public decimal MinimalAmount { get; set; }

    public string PayrollUnit { get; set; } = null!;

    public bool ApplyActivityRate { get; set; }

    public decimal AnnualHoursDivider { get; set; }

    public bool ReportToWorkedDays { get; set; }

    public virtual SalaryInsuranceName? SalaryInsuranceName { get; set; }

}
