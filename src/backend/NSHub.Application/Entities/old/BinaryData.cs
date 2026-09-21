using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class BinaryData : BaseEntity
{
    public bool IsEncrypted { get; set; }

    public bool IsCompressed { get; set; }

    public byte[] Content { get; set; } = null!;

    public Guid DescriptionNameId { get; set; }

    public virtual TranslationGroup? DescriptionName { get; set; }

    public Guid DescriptionFileNameId { get; set; }
    public virtual TranslationGroup? DescriptionFileName { get; set; }
}
