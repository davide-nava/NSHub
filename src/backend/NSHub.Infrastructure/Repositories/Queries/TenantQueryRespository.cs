// <copyright file="TenantQueryRespository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Interfaces.Repositories.Queries;
using NSHub.Caches.Interfaces;
using NSHub.Infrastructure.DbContexts;

namespace NSHub.Infrastructure.Repositories.Queries;

public class TenantQueryRespository(TenantDbContext dbContext, INSHubMemoryCacheService? nSHubMemoryCacheService) : BaseQueryRepository<Tenant>(dbContext, nSHubMemoryCacheService), ITenantQueryRespository
{
    public async Task<IEnumerable<string>> GetConnectionStringAsync(CancellationToken cancellationToken = default)
    {
        const string tmpKey = "Tenant_GetConnectionStringAsync";
        if (nSHubMemoryCacheService != null && nSHubMemoryCacheService.Cache.TryGetValue(tmpKey, out IEnumerable<string>? items))
        {
            return items ?? [];
        }

        var query = dbContext.Tenants.AsNoTracking();

        items = await query.Select(e => e.ConnectionString).ToListAsync(cancellationToken);

        if (nSHubMemoryCacheService != null && (items?.Any() ?? false))
        {
            nSHubMemoryCacheService.SetKey(tmpKey);
            nSHubMemoryCacheService.Cache.Set(tmpKey, items);
        }

        return items ?? [];
    }

    public async Task<string> GetConnectionStringAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var tmpKey = $"Tenant_GetConnectionStringAsync_Id:{id}";
        if (nSHubMemoryCacheService != null && nSHubMemoryCacheService.Cache.TryGetValue(tmpKey, out string? item))
        {
            return item ?? string.Empty;
        }

        var query = dbContext.Tenants.AsNoTracking();

        item = await query.Where(e => e.Id == id).Select(e => e.ConnectionString).FirstOrDefaultAsync(cancellationToken);

        if (nSHubMemoryCacheService != null && !string.IsNullOrWhiteSpace(item))
        {
            nSHubMemoryCacheService.SetKey(tmpKey);
            nSHubMemoryCacheService.Cache.Set(tmpKey, item);
        }

        return item ?? string.Empty;
    }
}
