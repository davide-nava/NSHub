// <copyright file="SettingQueryService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Interfaces;
using NSHub.Application.Interfaces.Repositories.Queries;
using NSHub.Application.Interfaces.Services.Queries;
using NSHub.Application.PlanetHub.Models.EntityModels;

namespace NSHub.Application.Services.Queries;

public class SettingQueryService(ISettingQueryRepository repo, IMapper<Setting, SettingModel> mapper) : BaseQueryService<Setting, SettingModel, ISettingQueryRepository>(repo,  mapper), ISettingQueryService;

