// <copyright file="TenantQueryRespository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.ApplicationCore.Interfaces.Repositories.Queries;
using PlanetHub.Caches.Interfaces;
using PlanetHub.Infrastructure.DbContexts;

namespace PlanetHub.Infrastructure.Repositories.Queries;

public class TenantQueryRespository(TenantDbContext dbContext, IPlanetHubMemoryCacheService? planetHubMemoryCacheService) : BaseQueryRepository<Tenant>(dbContext, planetHubMemoryCacheService), ITenantQueryRespository
{
    public async Task<IEnumerable<string>> GetConnectionStringAsync(CancellationToken cancellationToken = default)
    {
        const string tmpKey = "Tenant_GetConnectionStringAsync";
        if (planetHubMemoryCacheService != null && planetHubMemoryCacheService.Cache.TryGetValue(tmpKey, out IEnumerable<string>? items))
        {
            return items ?? [];
        }

        var query = dbContext.Tenants.AsNoTracking();

        items = await query.Select(e => e.ConnectionString).ToListAsync(cancellationToken);

        if (planetHubMemoryCacheService != null && (items?.Any() ?? false))
        {
            planetHubMemoryCacheService.SetKey(tmpKey);
            planetHubMemoryCacheService.Cache.Set(tmpKey, items);
        }

        return items ?? [];
    }

    public async Task<string> GetConnectionStringAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var tmpKey = $"Tenant_GetConnectionStringAsync_Id:{id}";
        if (planetHubMemoryCacheService != null && planetHubMemoryCacheService.Cache.TryGetValue(tmpKey, out string? item))
        {
            return item ?? string.Empty;
        }

        var query = dbContext.Tenants.AsNoTracking();

        item = await query.Where(e => e.Id == id).Select(e => e.ConnectionString).FirstOrDefaultAsync(cancellationToken);

        if (planetHubMemoryCacheService != null && !string.IsNullOrWhiteSpace(item))
        {
            planetHubMemoryCacheService.SetKey(tmpKey);
            planetHubMemoryCacheService.Cache.Set(tmpKey, item);
        }

        return item ?? string.Empty;
    }
}
