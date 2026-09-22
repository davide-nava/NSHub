// <copyright file="LanguageCommandService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Interfaces;
using NSHub.Application.Interfaces.Repositories.Commands;
using NSHub.Application.Interfaces.Services.Commands;
using NSHub.Application.NSHub.Models.EntityModels;

namespace NSHub.Application.Services.Commands;

public class LanguageCommandService(ILanguageCommandRepository repo, IMapper<Language, LanguageModel> mapper) : BaseCommandService<Language, LanguageModel, ILanguageCommandRepository>(repo, mapper), ILanguageCommandService;

