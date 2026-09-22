using System;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class Recall : BaseEntity
{
    public int Level { get; set; }

    // TODO: Check type
    public int DelayGg { get; set; }

    public bool IsForcePrint { get; set; }

    public Guid DescriptionFooterId { get; set; }

    public Guid DescriptionHeaderId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual TranslationGroup? DescriptionFooter { get; set; }

    public virtual TranslationGroup? DescriptionHeader { get; set; }

}
