using System;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryInsuranceLppGroup : BaseEntity
{
    public Guid SalaryInsuranceLppId { get; set; }

    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual SalaryInsuranceLpp? SalaryInsuranceLpp { get; set; }
}
