using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class SalaryConstant : BaseEntity
{
    public string Name { get; set; } = null!;

    public bool Deactivated { get; set; }

    public Guid ConstantCategoryId { get; set; }

    public string StandardComputingCode { get; set; } = null!;

    public string ExternalProcedureHookupCode { get; set; } = null!;

    public int Position { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual ConstantCategory? ConstantCategory { get; set; }
    public virtual SalaryConstantCategory? SalaryConstantCategory { get; set; }

    public virtual SalaryConfigurationRule? SalaryConfigurationRule { get; set; }

}
