using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CostCenterLevelArea : BaseEntity
{
    public Guid AreaId { get; set; }

    public Guid CostCenterLevelId { get; set; }

    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public Guid CostCenter { get; set; }

    public virtual CostCenter? CostCenter { get; set; }

    public virtual Area? Area { get; set; }
    public virtual CostCenterLevel? CostCenterLevel { get; set; }

}
