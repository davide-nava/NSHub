using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryInsuranceIgmDetail : BaseEntity
{
    public Guid SalaryInsuranceIgmId { get; set; }

    public decimal SalaryFrom { get; set; }

    public decimal SalaryMax { get; set; }

    public decimal EmployeeManRate { get; set; }

    public decimal EmployeeWomanRate { get; set; }

    public decimal EmployerManRate { get; set; }

    public decimal EmployerWomanRate { get; set; }

    public string CategoryCode { get; set; } = null!;

    public bool NotInsured { get; set; }

    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual SalaryInsuranceIgm? SalaryInsuranceIgm { get; set; }
}
