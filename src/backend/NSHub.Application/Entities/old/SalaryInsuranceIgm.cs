using System;
using System.Collections.Generic;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryInsuranceIgm : BaseEntity
{
    public Guid SalaryInsuranceNameId { get; set; }

    public DateTime ValidFrom { get; set; }

    public string InsuranceNumber { get; set; } = null!;

    public string CustomerNumber { get; set; } = null!;

    public string ContractNumber { get; set; } = null!;

    public virtual SalaryInsuranceName? SalaryInsuranceName { get; set; }

}
