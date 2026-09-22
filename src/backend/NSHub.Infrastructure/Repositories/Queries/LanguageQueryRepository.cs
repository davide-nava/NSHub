// <copyright file="LanguageQueryRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Interfaces.Repositories.Queries;
using NSHub.Caches.Interfaces;
using NSHub.Infrastructure.DbContexts;

namespace NSHub.Infrastructure.Repositories.Queries;

public class LanguageQueryRepository(TenantDbContext dbContext, INSHubMemoryCacheService? nSHubMemoryCacheService = null) : BaseQueryRepository<Language>(dbContext, nSHubMemoryCacheService), ILanguageQueryRepository;
