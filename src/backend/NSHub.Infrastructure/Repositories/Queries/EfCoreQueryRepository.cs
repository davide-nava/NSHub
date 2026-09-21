// <copyright file="EfCoreQueryRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PlanetHub.ApplicationCore.Interfaces.Repositories.Queries;
using PlanetHub.Infrastructure.DbContexts;

namespace PlanetHub.Infrastructure.Repositories.Queries;

public class EfCoreQueryRepository(TenantDbContext dbContext) : IEfCoreQueryRepository
{
    public async Task<bool> GenericAsync()
    {
        var clrTypes = dbContext.Model.GetEntityTypes()
            .Select(entityType => entityType.ClrType)
            .Where(clrType => clrType is not null);

        foreach (var clrType in clrTypes)
        {
            try
            {
                var set = dbContext.GetType()
                    .GetMethod(nameof(DbContext.Set), Type.EmptyTypes)?
                    .MakeGenericMethod(clrType!)
                    .Invoke(dbContext, null) as IQueryable;

                if (set is null)
                {
                    continue;
                }

                var castMethod = typeof(Queryable).GetMethod(nameof(Queryable.Cast), new[] { typeof(IQueryable) })?.MakeGenericMethod(typeof(object));

                if (castMethod is null)
                {
                    continue;
                }

                var castQuery = (IQueryable<object>?)castMethod.Invoke(null, new object[] { set });

                if (castQuery is null)
                {
                    continue;
                }

                await EntityFrameworkQueryableExtensions.FirstOrDefaultAsync(castQuery.AsNoTracking());
            }
            catch (Exception)
            {
                // Ignora errori su un singolo DbSet e continua con gli altri
            }
        }

        return true;
    }
}
