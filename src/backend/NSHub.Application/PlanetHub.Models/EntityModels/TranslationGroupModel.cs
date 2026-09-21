// <copyright file="TranslationGroupModel.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.PlanetHub.Models.EntityModels;

public class TranslationGroupModel : BaseEntityModel
{
    public ICollection<TranslationModel> Translations { get; set; } = [];

    public Guid LanguageDefaultId { get; set; }

    public virtual LanguageModel? LanguageDefault { get; set; }
}

