// <copyright file="Translation.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Translation : BaseEntity
{
    public string Text { get; set; } = null!;

    public Guid LanguageId { get; set; }

    public Guid TranslationGroupId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual TranslationGroup? TranslationGroup { get; set; }

}
