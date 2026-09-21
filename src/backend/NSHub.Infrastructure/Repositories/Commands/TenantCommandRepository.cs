// <copyright file="TenantCommandRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.ApplicationCore.Interfaces.Repositories.Commands;
using PlanetHub.Caches.Interfaces;
using PlanetHub.Infrastructure.DbContexts;

namespace PlanetHub.Infrastructure.Repositories.Commands;

public class TenantCommandRepository(TenantDbContext dbContext, IPlanetHubMemoryCacheService? planetHubMemoryCacheService = null) : BaseCommandRepository<PlanetHub.ApplicationCore.Entities.Tenant>(dbContext, planetHubMemoryCacheService), ITenantCommandRepository;
