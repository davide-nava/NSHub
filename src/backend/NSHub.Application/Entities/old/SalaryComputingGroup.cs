using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class SalaryComputingGroup : BaseEntity
{
    public string Code { get; set; }

    public bool DisableTaxAtSource { get; set; }

    public bool DisableAvsAd { get; set; }

    public bool DisableLainf { get; set; }

    public bool DisableLainfC { get; set; }

    public bool DisableIgm { get; set; }

    public bool DisableLpp { get; set; }

    public bool DisableLppTable { get; set; }

    public bool DisableCpc { get; set; }

    public bool DisablePean { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
