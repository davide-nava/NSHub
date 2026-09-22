using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CanteenMenu : BaseEntity
{
    public string Code { get; set; } = null!;

    public ColorType ColorType { get; set; }

    public decimal EmployeePrice { get; set; }

    public Guid AccountId { get; set; }

    public decimal AccountValue { get; set; }

    public Guid AccountValueFormulaId { get; set; }

    public virtual Account? Account { get; set; }
    public virtual AccountValueFormula? AccountValueFormula { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


}
