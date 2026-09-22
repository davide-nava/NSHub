using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ArticleLevelEntry : BaseEntity
{
    public string Code { get; set; } = null!;

    public int LevelNumber { get; set; }

    public Guid ParentId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual ArticleLevelEntry? ArticleLevelEntryParent { get; set; }
}
