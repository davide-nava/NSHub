using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class GridConfiguration : BaseEntity
{
    public Guid GridLayoutId { get; set; }

    public Guid GridFilterId { get; set; }

    public Guid GridOrderingId { get; set; }

    public bool Predefined { get; set; }

    public string CodeGrid { get; set; } = null!;

    public string CodeUser { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual GridLayout? GridLayout { get; set; }
    public virtual GridFilter? GridFilter { get; set; }
    public virtual GridOrdering? GridOrdering { get; set; }


}
