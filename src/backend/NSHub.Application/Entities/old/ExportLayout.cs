using System;
using System.Collections.Generic;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ExportLayout : BaseEntity
{
    public string Name { get; set; } = null!;

    public string Layout { get; set; } = null!;

    public Guid TableId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual Table? Table { get; set; }
}
