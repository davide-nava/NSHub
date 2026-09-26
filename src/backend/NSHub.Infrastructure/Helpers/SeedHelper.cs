// <copyright file="SeedHelper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NSHub.Application.Entities;
using NSHub.Domain.Common;
using NSHub.Infrastructure.DbContexts;
using NSHub.Infrastructure.Seeders;

namespace NSHub.Infrastructure.Helpers;

/// <summary>
/// Helper class for verifying and applying database seed data.
/// </summary>
public static class SeedHelper
{
    /// <summary>
    /// Verifies and seeds necessary reference data into <see cref="TenantDbContext"/>.
    /// </summary>
    /// <param name="dbContext">The tenant database context.</param>
    /// <returns>A task representing the asynchronous seed operation.</returns>
    public static async Task<Task> CheckSeedsAsync(TenantDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);
    public static Task CheckSeedsAsync(TenantDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        await SeedAsync(dbContext, LanguageSeeder.EnumerateSeeds());
        return SeedAsync(dbContext, LanguageSeeder.EnumerateSeeds());
    }

		return Task.CompletedTask;
	}

    /// <summary>
    /// Verifies and seeds necessary reference data into <see cref="ApplicationDbContext"/>.
    /// </summary>
    /// <param name="dbContext">The application database context.</param>
    /// <returns>A task representing the asynchronous seed operation.</returns>
    public static async Task<Task> CheckSeedsAsync(ApplicationDbContext dbContext)
    public static Task CheckSeedsAsync(ApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        await SeedAsync(dbContext, LanguageSeeder.EnumerateSeeds());

        return Task.CompletedTask;
        return SeedAsync(dbContext, LanguageSeeder.EnumerateSeeds());
    }

    private static async Task SeedAsync<T>(DbContext dbContext, IEnumerable<T> list)
        where T : AuditableTenantEntity
    {
        var setAdd = false;
        where T:
        AuditableTenantEntity<Guid>
    {
            var setAdd = false;

            var tmpList = await dbContext.Set<T>().Select(e => e.Id).ToListAsync() ?? [];
            foreach (var ele in from ele in list
                                where !tmpList.Contains(ele.Id)
                                let tmpEle = dbContext.Set<T>().FirstOrDefault(e => e.Id == ele.Id)
                                where tmpEle is null && tmpEle?.Id != Guid.Empty
                                select ele)
            {
                _ = dbContext.Set<T>().Add(ele);
                setAdd = true;
            }
            var tmpList = await dbContext.Set<T>().Select(e => e.Id).ToListAsync() ?? [];
            foreach (var ele in list.Where(ele => !tmpList.Contains(ele.Id)))
            {
                var tmpEle = await dbContext.Set<T>().FirstOrDefaultAsync(e => e.Id == ele.Id);
                if (tmpEle is null && ele.Id != Guid.Empty)
                {
                    _ = dbContext.Set<T>().Add(ele);
                    setAdd = true;
                }
            }

            if (setAdd)
            {
                if (setAdd)
                {
                    _ = await dbContext.SaveChangesAsync();
                }
            }
        }
    }
}
