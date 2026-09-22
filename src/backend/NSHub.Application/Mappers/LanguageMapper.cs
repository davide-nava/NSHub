// <copyright file="LanguageMapper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Interfaces;
using NSHub.Application.NSHub.Models.EntityModels;
using Riok.Mapperly.Abstractions;

namespace NSHub.Application.Mappers;

[Mapper(UseDeepCloning = true)]
public partial class LanguageMapper : IMapper<Language, LanguageModel>
{
    public partial Language ToEntity(LanguageModel model);

    public partial IEnumerable<Language> ToEntities(IEnumerable<LanguageModel> dtos);

    public partial LanguageModel ToModel(Language entity);

    public partial IEnumerable<LanguageModel> ToModels(IEnumerable<Language> entities);

    public partial void UpdateEntity(LanguageModel model, Language entity);

}

