using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CostCenter : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid CostCenterLevelId { get; set; }

    public DateTime ValidFrom { get; set; }

    public DateTime ValidUntil { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


}
