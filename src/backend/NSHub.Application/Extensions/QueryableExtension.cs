// <copyright file="QueryableExtension.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using System.Transactions;
using NSHub.Application.Constants;
using NSHub.Domain.Enums;

namespace NSHub.Application.Extensions;

public static class QueryableExtension
{
	public static IOrderedQueryable<T> OrderByField<T>(this IQueryable<T> q, string sortField, bool isAscending)
	{
		ArgumentNullException.ThrowIfNull(q);
		var param = Expression.Parameter(typeof(T), "p");
		var prop = Expression.Property(param, sortField);
		var exp = Expression.Lambda(prop, param);

		var method = isAscending ? DomainConstant.OrderBy : DomainConstant.OrderByDescending;
		var types = new[] { q.ElementType, exp.Body.Type };
		var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);

		if (q.Provider.CreateQuery<T>(mce) is not IOrderedQueryable<T> query)
		{
			throw new InvalidOperationException();
		}

		return query;
	}

	public static IOrderedQueryable<T> OrderByExp<T>(this IQueryable<T> q, LambdaExpression exp, bool isAscending)
	{
		ArgumentNullException.ThrowIfNull(exp);
		ArgumentNullException.ThrowIfNull(q);
		var method = isAscending ? DomainConstant.OrderBy : DomainConstant.OrderByDescending;
		var types = new[] { q.ElementType, exp.Body.Type };
		var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);

		if (q.Provider.CreateQuery<T>(mce) is not IOrderedQueryable<T> query)
		{
			throw new InvalidOperationException();
		}

		return query;
	}

	public static IOrderedQueryable<TEntity> OrderBy<TEntity, TKey>(this IQueryable<TEntity> queryable, Expression<Func<TEntity, TKey>> keySelector, SortingDirectionType direction)
	{
		ArgumentNullException.ThrowIfNull(keySelector);
		ArgumentNullException.ThrowIfNull(queryable);
		var method = direction == SortingDirectionType.Asc ? DomainConstant.OrderBy : DomainConstant.OrderByDescending;
		var types = new[] { queryable.ElementType, keySelector.Body.Type };
		var mce = Expression.Call(typeof(Queryable), method, types, queryable.Expression, keySelector);

		if (queryable.Provider.CreateQuery<TEntity>(mce) is not IOrderedQueryable<TEntity> query)
		{
			throw new InvalidOperationException();
		}

		return query;
	}

	public static IOrderedQueryable<T> ThenByField<T>(this IOrderedQueryable<T> q, string sortField, bool isAscending)
	{
		ArgumentNullException.ThrowIfNull(q);
		var param = Expression.Parameter(typeof(T), "p");
		var prop = Expression.Property(param, sortField);
		var exp = Expression.Lambda(prop, param);

		var method = isAscending ? DomainConstant.ThenBy : DomainConstant.ThenByDescending;
		var types = new[] { q.ElementType, exp.Body.Type };
		var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);

		if (q.Provider.CreateQuery<T>(mce) is not IOrderedQueryable<T> query)
		{
			throw new InvalidOperationException("Invalid query");
		}

		return query;
	}

	public static IOrderedQueryable<T> ThenByExp<T>(this IOrderedQueryable<T> q, LambdaExpression exp, bool isAscending)
	{
		ArgumentNullException.ThrowIfNull(q);
		ArgumentNullException.ThrowIfNull(exp);
		var method = isAscending ? DomainConstant.ThenBy : DomainConstant.ThenByDescending;
		var types = new[] { q.ElementType, exp.Body.Type };
		var mce = Expression.Call(typeof(Queryable), method, types, q.Expression, exp);

		if (q.Provider.CreateQuery<T>(mce) is not IOrderedQueryable<T> query)
		{
			throw new InvalidOperationException();
		}

		return query;
	}

	public static IOrderedQueryable<TEntity> ThenBy<TEntity, TKey>(this IOrderedQueryable<TEntity> queryable, Expression<Func<TEntity, TKey>> keySelector, SortingDirectionType direction)
	{
		ArgumentNullException.ThrowIfNull(queryable);
		ArgumentNullException.ThrowIfNull(keySelector);

		var method = direction == SortingDirectionType.Asc ? DomainConstant.ThenBy : DomainConstant.ThenByDescending;
		var types = new[] { queryable.ElementType, keySelector.Body.Type };
		var mce = Expression.Call(typeof(Queryable), method, types, queryable.Expression, keySelector);

		if (queryable.Provider.CreateQuery<TEntity>(mce) is not IOrderedQueryable<TEntity> query)
		{
			throw new InvalidOperationException();
		}

		return query;
	}

	public static List<T> ToListReadUncommitted<T>(this IQueryable<T> query)
	{
		using var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
		{
			IsolationLevel = IsolationLevel.ReadUncommitted,
		});

		var toReturn = query.ToList();
		scope.Complete();

		return toReturn;
	}

	public static int CountReadUncommitted<T>(this IQueryable<T> query)
	{
		using var scope = new TransactionScope(TransactionScopeOption.Required, new TransactionOptions
		{
			IsolationLevel = IsolationLevel.ReadUncommitted,
		});

		var toReturn = query.Count();
		scope.Complete();

		return toReturn;
	}
}
