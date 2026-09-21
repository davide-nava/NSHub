using System;
using System.Collections.Generic;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryInsuranceName : BaseEntity
{
    public InsuranceType InsuranceType { get; set; }

    public string Name { get; set; } = null!;

    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public bool UseForAvs { get; set; }

    public bool UseForCaf { get; set; }

}
