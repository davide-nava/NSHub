// <copyright file="BaseQueryRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using System.Linq.Expressions;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.ApplicationCore.Interfaces.Repositories.Queries;
using PlanetHub.Caches.Interfaces;
using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.Infrastructure.Repositories.Queries;

public class BaseQueryRepository<TEntity>(DbContext dbContext, IPlanetHubMemoryCacheService? planetHubMemoryCacheService = null) : IBaseQueryRepository<TEntity>
		where TEntity : BaseEntity
{
	public virtual Task<IEnumerable<LookupModel>?> LookupAsync( CancellationToken cancellationToken = default) => throw new NotImplementedException("LookupAsync method is not implemented for this service.");

    public virtual async Task<IEnumerable<TEntity>?> ListAsync( PaginationModel paginationModel, CancellationToken cancellationToken = default)
	{
		ArgumentNullException.ThrowIfNull(paginationModel);
		//if (!string.IsNullOrWhiteSpace(baseListEntityParameter.OrderParameter?.AttributeName))
		//{
		//	propertyName = typeof(TEntity)
		//		.GetProperty(baseListEntityParameter.OrderParameter.AttributeName, BindingFlags.IgnoreCase | BindingFlags.Public | BindingFlags.Instance)
		//		?.Name ?? throw new ArgumentException(
		//			$"OrderBy: The associated Attribute to the given {baseListEntityParameter.OrderParameter?.AttributeName} could not be resolved",
		//			baseListEntityParameter.OrderParameter?.AttributeName);
		//}


		var tmpKey = $"{typeof(TEntity).Name}_List_TenantId:{tenantId}_PageNumber:{paginationModel.PageNumber ?? 0}_PageSize:{paginationModel.PageSize ?? 0}_SortingDirectionType:{Enum.GetName(paginationModel.SortingDirectionType)}_SortingBy:{paginationModel.SortingBy}";

		if (planetHubMemoryCacheService != null && planetHubMemoryCacheService.Cache.TryGetValue(tmpKey, out IEnumerable<TEntity>? items))
		{
			return items;
		}

		var query = dbContext.Set<TEntity>().AsNoTracking();

		if (!string.IsNullOrWhiteSpace(paginationModel.SortingBy))
		{
			query = OrderByProperty(query, paginationModel.SortingBy, paginationModel.SortingDirectionType);
		}

		if (paginationModel.PageNumber.HasValue && paginationModel.PageSize.HasValue && paginationModel.PageSize.Value > 0 && paginationModel.PageNumber.Value >= 0)
		{
			query = query.Take(paginationModel.PageSize.Value).Skip((paginationModel.PageNumber.Value < 1 ? 0 : (paginationModel.PageNumber.Value - 1)) * paginationModel.PageSize.Value);
		}

		items = await query.ToListAsync(cancellationToken);

		if (planetHubMemoryCacheService != null && (items?.Any() ?? false))
		{
			planetHubMemoryCacheService.SetKey(tmpKey);
			planetHubMemoryCacheService.Cache.Set(tmpKey, items);
		}

		return items;
	}

	public virtual async Task<int> CountAsync( CancellationToken cancellationToken = default)
	{
		var tmpKey = $"{typeof(TEntity).Name}_Count_TenantId:{tenantId}";

		if (planetHubMemoryCacheService != null && planetHubMemoryCacheService.Cache.TryGetValue(tmpKey, out int item))
		{
			return item;
		}

		var query = dbContext.Set<TEntity>().AsNoTracking();

		item = await query.CountAsync(cancellationToken);

		if (planetHubMemoryCacheService != null)
		{
			planetHubMemoryCacheService.SetKey(tmpKey);
			planetHubMemoryCacheService.Cache.Set(tmpKey, item);
		}

		return item;
	}

	public virtual async Task<TEntity?> GetAsync(Guid id,  CancellationToken cancellationToken = default)
	{
		var tmpKey = $"{typeof(TEntity).Name}_Get_TenantId:{tenantId}_Id:{id}";

		if (planetHubMemoryCacheService != null && planetHubMemoryCacheService.Cache.TryGetValue(tmpKey, out TEntity? item))
		{
			return item;
		}

		var query = dbContext.Set<TEntity>().AsNoTracking();

		item = await query.Where(e => e.Id == id).FirstOrDefaultAsync(cancellationToken);

		if (planetHubMemoryCacheService != null)
		{
			planetHubMemoryCacheService.SetKey(tmpKey);
			planetHubMemoryCacheService.Cache.Set(tmpKey, item);
		}

		return item;
	}

	private static IQueryable<TEntity> OrderByProperty(IQueryable<TEntity> source, string propertyName, SortingDirectionType sortingDirectionType)
	{
		var parameter = Expression.Parameter(typeof(TEntity), "x");
		var property = Expression.PropertyOrField(parameter, propertyName);
		var lambda = Expression.Lambda(property, parameter);

		var methodName = sortingDirectionType == SortingDirectionType.Desc ? "OrderByDescending" : "OrderBy";

		var result = typeof(Queryable).GetMethods()
			.First(m => m.Name == methodName && m.GetParameters().Length == 2)
			.MakeGenericMethod(typeof(TEntity), property.Type)
			.Invoke(null, [source, lambda]);

		return (IQueryable<TEntity>)result!;
	}
}

//public static IQueryable<T> OrderByProperties<T>(
//	this IQueryable<T> source,
//	string orderBy)
//	{
//		if (string.IsNullOrWhiteSpace(orderBy))
//			return source;

//		var parameters = Expression.Parameter(typeof(T), "x");
//		IQueryable<T> result = source;

//		foreach (var clause in orderBy.Split(','))
//		{
//			var parts = clause.Trim().Split(' ');
//			var propertyName = parts[0];
//			var descending = parts.Length > 1 && parts[1].Equals("desc", StringComparison.OrdinalIgnoreCase);

//			var property = Expression.PropertyOrField(parameters, propertyName);
//			var lambda = Expression.Lambda(property, parameters);

//			string methodName;

//			// Se è il primo ordinamento → OrderBy / OrderByDescending
//			// Altrimenti → ThenBy / ThenByDescending
//			if (result == source)
//				methodName = descending ? "OrderByDescending" : "OrderBy";
//			else
//				methodName = descending ? "ThenByDescending" : "ThenBy";

//			result = (IQueryable<T>)typeof(Queryable).GetMethods()
//				.First(m => m.Name == methodName
//						 && m.GetParameters().Length == 2)
//				.MakeGenericMethod(typeof(T), property.Type)
//				.Invoke(null, new object[] { result, lambda })!;
//		}

//		return result;
//	}

