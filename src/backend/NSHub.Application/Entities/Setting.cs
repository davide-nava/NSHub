// <copyright file="Setting.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Setting : BaseEntityType
{

    public string Group { get; set; } = null!;

    public string Key { get; set; } = null!;

    public string Value { get; set; } = null!;

    public bool Encrypted { get; set; }

    public Guid TranslationGroupTitleId { get; set; }

    public virtual TranslationGroup? TranslationGroupTitle { get; set; }

}
