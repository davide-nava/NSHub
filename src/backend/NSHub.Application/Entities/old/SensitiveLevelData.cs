using System;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SensitiveLevelData : BaseEntity
{
    public bool IsMaskedData { get; set; }

    // TODO: Check type
    public int SensitiveLevel { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
