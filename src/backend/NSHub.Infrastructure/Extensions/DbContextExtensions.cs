// <copyright file="DbContextExtensions.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace NSHub.Infrastructure.Extensions;

/// <summary>
/// Extension methods for Entity Framework Core <see cref="DbContext"/>.
/// </summary>
public static class DbContextExtensions
{
    /// <summary>
    /// Discovers and returns all public <see cref="DbSet{TEntity}"/> properties configured on the given database context.
    /// </summary>
    /// <param name="context">The database context.</param>
    /// <returns>A sequence of tuples containing the entity type and the corresponding DbSet instance.</returns>
    public static IEnumerable<(Type? EntityType, object? DbSet)> GetAllDbSets(this DbContext context)
    {
        var props = context.GetType()
            .GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.PropertyType.IsGenericType &&
                        p.PropertyType.GetGenericTypeDefinition() == typeof(DbSet<>));

        foreach (var prop in props)
        {
            var entityType = prop.PropertyType.GetGenericArguments()[0];
            var dbSet = prop.GetValue(context);
            yield return (entityType, dbSet);
        }
    }
}
