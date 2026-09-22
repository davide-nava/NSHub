using System;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryInsuranceLppGroup : BaseEntity
{
    public Guid SalaryInsuranceLppId { get; set; }

    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual SalaryInsuranceLpp? SalaryInsuranceLpp { get; set; }
}
