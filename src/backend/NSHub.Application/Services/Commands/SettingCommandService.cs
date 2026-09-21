// <copyright file="SettingCommandService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Interfaces;
using NSHub.Application.Interfaces.Repositories.Commands;
using NSHub.Application.Interfaces.Services.Commands;
using NSHub.Application.PlanetHub.Models.EntityModels;

namespace NSHub.Application.Services.Commands;

public class SettingCommandService(ISettingCommandRepository repo, IMapper<Setting, SettingModel> mapper) : BaseCommandService<Setting, SettingModel, ISettingCommandRepository>(repo, mapper), ISettingCommandService;

