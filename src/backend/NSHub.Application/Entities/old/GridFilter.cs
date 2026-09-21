using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class GridFilter : BaseEntity
{
    public bool Restricted { get; set; }

    public bool Predefined { get; set; }

    public string CodeGrid { get; set; } = null!;

    public string CodeUser { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Grid? Grid { get; set; } = null!;

}
