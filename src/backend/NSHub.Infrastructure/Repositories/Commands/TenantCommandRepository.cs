// <copyright file="TenantCommandRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Interfaces.Repositories.Commands;
using NSHub.Caches.Interfaces;
using NSHub.Infrastructure.DbContexts;

namespace NSHub.Infrastructure.Repositories.Commands;

public class TenantCommandRepository(TenantDbContext dbContext, INSHubMemoryCacheService? nSHubMemoryCacheService = null) : BaseCommandRepository<NSHub.ApplicationCore.Entities.Tenant>(dbContext, nSHubMemoryCacheService), ITenantCommandRepository;
