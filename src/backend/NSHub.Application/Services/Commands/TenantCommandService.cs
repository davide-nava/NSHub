// <copyright file="TenantCommandService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Interfaces;
using NSHub.Application.Interfaces.Repositories.Commands;
using NSHub.Application.Interfaces.Services.Commands;
using NSHub.Application.PlanetHub.Models.EntityModels;

namespace NSHub.Application.Services.Commands;

public class TenantCommandService(ITenantCommandRepository repo, IMapper<Tenant, TenantModel> mapper) : BaseCommandService<Tenant, TenantModel, ITenantCommandRepository>(repo, mapper), ITenantCommandService;

