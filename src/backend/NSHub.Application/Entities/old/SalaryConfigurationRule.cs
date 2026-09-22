using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class SalaryConfigurationRule : BaseEntity
{
    public bool Visible { get; set; }

    public Guid VisibileFormulaId { get; set; }

    public bool CanWrite { get; set; }

    public Guid CanWriteFormulaId { get; set; }

    public bool CanUpdate { get; set; }

    public Guid CanUpdateFormulaId { get; set; }

    public bool Required { get; set; }

    public Guid RequiredFormulaId { get; set; }

    public bool Validation { get; set; }

    public Guid ValidationFormulaId { get; set; }

    public Guid DefaultValueFormulaId { get; set; }

    public bool AlertOnChange { get; set; }

    public Guid AlertOnChangeFormulaId { get; set; }

    public int Decimals { get; set; }

    public Guid SalaryConstantId { get; set; }

    public Guid DescriptionMessageId { get; set; }

    public virtual TranslationGroup? DescriptionMessage { get; set; }

    public virtual VisibileFormula? VisibileFormula { get; set; }
    public virtual CanWriteFormula? CanWriteFormula { get; set; }
    public virtual CanUpdateFormula? CanUpdateFormula { get; set; }
    public virtual RequiredFormula? RequiredFormula { get; set; }
    public virtual ValidationFormula? ValidationFormula { get; set; }
    public virtual DefaultValueFormula? DefaultValueFormula { get; set; }
    public virtual AlertOnChangeFormula? AlertOnChangeFormula { get; set; }
    public virtual SalaryConstant? SalaryConstant { get; set; }

}
