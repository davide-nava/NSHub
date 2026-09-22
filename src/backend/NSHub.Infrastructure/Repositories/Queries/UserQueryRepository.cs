// <copyright file="UserQueryRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Entities.Json;
using NSHub.ApplicationCore.Interfaces.Repositories.Queries;
using NSHub.Caches.Interfaces;
using NSHub.Infrastructure.DbContexts;

namespace NSHub.Infrastructure.Repositories.Queries;

public class UserQueryRepository(TenantDbContext dbContext, INSHubMemoryCacheService? nSHubMemoryCacheService = null) : BaseQueryRepository<User>(dbContext, nSHubMemoryCacheService), IUserQueryRepository
{
    public async Task<UserConfigurationJson?> GetUserConfigurationAsync(Guid userId, Guid tenantId, CancellationToken cancellationToken = default)
    {
        var tmpKey = $"User_GetUserConfigurationAsync_TenantId:{tenantId}_UserId:{userId}";

        if (nSHubMemoryCacheService != null && nSHubMemoryCacheService.Cache.TryGetValue(tmpKey, out UserConfigurationJson? item))
        {
            return item;
        }

        var query = dbContext.Set<User>().AsNoTracking();

        item = await query.Where(e => e.Id == userId).Select(e => e.Configuration).FirstOrDefaultAsync(cancellationToken);

        if (nSHubMemoryCacheService != null)
        {
            nSHubMemoryCacheService.SetKey(tmpKey);
            nSHubMemoryCacheService.Cache.Set(tmpKey, item);
        }

        return item;
    }

    public async Task<User?> GetUserLoggedAsync(Guid userId, Guid tenantId, CancellationToken cancellationToken = default)
    {
        var tmpKey = $"User_GetUserLoggedAsync_TenantId:{tenantId}_UserId:{userId}";

        if (nSHubMemoryCacheService != null && nSHubMemoryCacheService.Cache.TryGetValue(tmpKey, out User? item))
        {
            return item;
        }

        var query = dbContext.Users.AsNoTracking();

        item = await query.Where(e => e.Id == userId).FirstOrDefaultAsync(cancellationToken);

        if (nSHubMemoryCacheService != null)
        {
            nSHubMemoryCacheService.SetKey(tmpKey);
            nSHubMemoryCacheService.Cache.Set(tmpKey, item);
        }

        return item;
    }
}
