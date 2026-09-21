using System;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryInsuranceCpcPean : BaseEntity
{
    public Guid SalaryInsuranceNameId { get; set; }

    public DateTime ValidFrom { get; set; }

    // TODO: Check type
    public int Source { get; set; }

    public EmployeeComputingModeType EmployeeComputingModeType { get; set; }

    public decimal EmployeeValue { get; set; }

    public EmployerComputingModeType EmployerComputingModeType { get; set; }

    public decimal EmployerValue { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


    public virtual SalaryInsuranceName? SalaryInsuranceName { get; set; }
}
