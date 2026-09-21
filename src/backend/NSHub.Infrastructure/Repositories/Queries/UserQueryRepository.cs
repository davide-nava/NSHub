// <copyright file="UserQueryRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.ApplicationCore.Entities.Json;
using PlanetHub.ApplicationCore.Interfaces.Repositories.Queries;
using PlanetHub.Caches.Interfaces;
using PlanetHub.Infrastructure.DbContexts;

namespace PlanetHub.Infrastructure.Repositories.Queries;

public class UserQueryRepository(TenantDbContext dbContext, IPlanetHubMemoryCacheService? planetHubMemoryCacheService = null) : BaseQueryRepository<User>(dbContext, planetHubMemoryCacheService), IUserQueryRepository
{
    public async Task<UserConfigurationJson?> GetUserConfigurationAsync(Guid userId, Guid tenantId, CancellationToken cancellationToken = default)
    {
        var tmpKey = $"User_GetUserConfigurationAsync_TenantId:{tenantId}_UserId:{userId}";

        if (planetHubMemoryCacheService != null && planetHubMemoryCacheService.Cache.TryGetValue(tmpKey, out UserConfigurationJson? item))
        {
            return item;
        }

        var query = dbContext.Set<User>().AsNoTracking();

        item = await query.Where(e => e.Id == userId).Select(e => e.Configuration).FirstOrDefaultAsync(cancellationToken);

        if (planetHubMemoryCacheService != null)
        {
            planetHubMemoryCacheService.SetKey(tmpKey);
            planetHubMemoryCacheService.Cache.Set(tmpKey, item);
        }

        return item;
    }

    public async Task<User?> GetUserLoggedAsync(Guid userId, Guid tenantId, CancellationToken cancellationToken = default)
    {
        var tmpKey = $"User_GetUserLoggedAsync_TenantId:{tenantId}_UserId:{userId}";

        if (planetHubMemoryCacheService != null && planetHubMemoryCacheService.Cache.TryGetValue(tmpKey, out User? item))
        {
            return item;
        }

        var query = dbContext.Users.AsNoTracking();

        item = await query.Where(e => e.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if (planetHubMemoryCacheService != null)
        {
            planetHubMemoryCacheService.SetKey(tmpKey);
            planetHubMemoryCacheService.Cache.Set(tmpKey, item);
        }

        return item;
    }
}
