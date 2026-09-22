using System;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SensitiveLevelData : BaseEntity
{
    public bool IsMaskedData { get; set; }

    // TODO: Check type
    public int SensitiveLevel { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
