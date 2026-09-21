using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ArticleLevel : BaseEntity
{
    public int LevelNumber { get; set; }

    public Guid DescriptionId { get; set; }

    public bool Enabled { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
