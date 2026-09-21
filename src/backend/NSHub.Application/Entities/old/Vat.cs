using System;

using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class Vat : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public bool Sale { get; set; }

    public bool GoodsServices { get; set; }

    public bool Investment { get; set; }

    public bool IsCorrespondent { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
