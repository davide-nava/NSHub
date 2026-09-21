// <copyright file="DbContextExtensions.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Reflection;
using Microsoft.EntityFrameworkCore;

namespace NSHub.Infrastructure.Extensions;

public static class DbContextExtensions
{
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
