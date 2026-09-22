using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryInsuranceLainfDetail : BaseEntity
{
    public Guid InsuranceLainfId { get; set; }

    public string AgencyPartCode { get; set; } = null!;

    public decimal EmployeeAipRate { get; set; }

    public decimal EmployeeAinpRate { get; set; }

    public decimal EmployerAinpRate { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual SalaryInsuranceLainf? SalaryInsuranceLainf { get; set; } = null!;
}
