// <copyright file="Language.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Language : BaseEntityType
{


    public string Name { get; set; } = null!;



    public virtual ICollection<TranslationGroup> TranslationGroups { get; set; } = [];

    public virtual ICollection<Translation> Translations { get; set; } = [];

}
