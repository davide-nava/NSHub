using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryInsuranceLppDetail : BaseEntity
{
    public Guid SalaryInsuranceLppId { get; set; }

    public SexType SexType { get; set; }

    public int AgeFrom { get; set; }

    public int AgeTo { get; set; }

    public decimal SalaryMax { get; set; }

    public decimal EmployeeSavingRate { get; set; }

    public decimal EmployerSavingRate { get; set; }

    public decimal EmployeeSpecialRate { get; set; }

    public SalaryInsuranceLppDetailRiskType SalaryInsuranceLppDetailRiskType { get; set; }

    public decimal EmployerRiskRate { get; set; }

    public decimal EmployeeRiskFixedRate { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual SalaryInsuranceLpp? SalaryInsuranceLpp { get; set; }
}
