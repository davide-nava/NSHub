// <copyright file="SettingQueryRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.ApplicationCore.Interfaces.Repositories.Queries;
using PlanetHub.Caches.Interfaces;
using PlanetHub.Infrastructure.DbContexts;

namespace PlanetHub.Infrastructure.Repositories.Queries;

public class SettingQueryRepository(TenantDbContext dbContext, IPlanetHubMemoryCacheService? planetHubMemoryCacheService = null) : BaseQueryRepository<Setting>(dbContext, planetHubMemoryCacheService), ISettingQueryRepository;
