using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CustomFunction : BaseEntity
{
    public int Position { get; set; }

    public string FileNameAndPath { get; set; } = null!;

    public string Code { get; set; } = null!;

    public string FormUniqueId { get; set; } = null!;

    public byte[] Icon { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
