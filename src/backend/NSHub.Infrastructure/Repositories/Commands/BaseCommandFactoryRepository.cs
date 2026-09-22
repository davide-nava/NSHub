// <copyright file="BaseCommandFactoryRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>


using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Interfaces.Repositories.Commands;
using NSHub.Caches.Interfaces;

namespace NSHub.Infrastructure.Repositories.Commands;

public class BaseCommandFactoryRepository<TEntity>(IDbContextFactory<DbContext> factory, INSHubMemoryCacheService? nSHubMemoryCacheService = null) : IBaseCommandRepository<TEntity>
		where TEntity : BaseEntity
{
	public virtual async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default)
	{
		nSHubMemoryCacheService?.RemoveContainsKey($"{typeof(TEntity).Name}_");

		await using var dbContext = factory.CreateDbContext();
		var item = await dbContext.Set<TEntity>().Where(e => e.Id == id).FirstOrDefaultAsync(cancellationToken);

		if (item == null)
		{
			return -1;
		}

		dbContext.Set<TEntity>().Remove(item);

		return await dbContext.SaveChangesAsync(cancellationToken);
	}

	public virtual async Task<TEntity> UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		ArgumentNullException.ThrowIfNull(entity);
		nSHubMemoryCacheService?.RemoveContainsKey($"{typeof(TEntity).Name}_");

		await using var dbContext = factory.CreateDbContext();
		var hasTx = dbContext.Database.CurrentTransaction != null;
		var entry = dbContext.Entry(entity);

		entry.State = EntityState.Modified;

		await dbContext.SaveChangesAsync(cancellationToken);

		if (!hasTx)
		{
			entry.State = EntityState.Detached;
		}

		if (nSHubMemoryCacheService != null)
		{
			nSHubMemoryCacheService.SetKey($"{typeof(TEntity).Name}_Get_id:{entity.Id}_TenantId:{tenantId}");
			nSHubMemoryCacheService.Cache.Set($"{typeof(TEntity).Name}_Get_id:{entity.Id}_TenantId:{tenantId}", entity);
		}

		return entry.Entity;
	}

	public virtual async Task<TEntity> CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
	{
		ArgumentNullException.ThrowIfNull(entity);
		nSHubMemoryCacheService?.RemoveContainsKey($"{typeof(TEntity).Name}_");

		await using var dbContext = factory.CreateDbContext();
		var hasTx = dbContext.Database.CurrentTransaction != null;
		var entry = dbContext.Entry(entity);

		entry.State = EntityState.Added;

		await dbContext.SaveChangesAsync(cancellationToken);

		if (!hasTx)
		{
			entry.State = EntityState.Detached;
		}

		if (nSHubMemoryCacheService != null)
		{
			nSHubMemoryCacheService.SetKey($"{typeof(TEntity).Name}_Get_id:{entity.Id}_TenantId:{tenantId}");
			nSHubMemoryCacheService.Cache.Set($"{typeof(TEntity).Name}_Get_id:{entity.Id}_TenantId:{tenantId}", entity);
		}

		return entry.Entity;
	}
}
