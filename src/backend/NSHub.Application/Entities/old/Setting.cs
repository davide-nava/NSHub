// <copyright file="Setting.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class Setting : BaseEntity
{
    public string Group { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public bool IsEncrypted { get; set; }

    public Guid DescriptionGroupId { get; set; }

    public virtual TranslationGroup? DescriptionGroup { get; set; }

    public Guid DescriptionTitleId { get; set; }
    public virtual TranslationGroup? DescriptionTitle { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
