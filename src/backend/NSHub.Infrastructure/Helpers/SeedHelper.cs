// <copyright file="SeedHelper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using NSHub.Application.Entities;
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
    public static async Task<System.Threading.Tasks.Task> CheckSeedsAsync(TenantDbContext dbContext)
	{
		ArgumentNullException.ThrowIfNull(dbContext);

		await SeedAsync(dbContext, LanguageSeeder.EnumerateSeeds());

		return System.Threading.Tasks.Task.CompletedTask;
	}

    /// <summary>
    /// Verifies and seeds necessary reference data into <see cref="ApplicationDbContext"/>.
    /// </summary>
    /// <param name="dbContext">The application database context.</param>
    /// <returns>A task representing the asynchronous seed operation.</returns>
    public static async Task<System.Threading.Tasks.Task> CheckSeedsAsync(ApplicationDbContext dbContext)
    {
        ArgumentNullException.ThrowIfNull(dbContext);

        await SeedAsync(dbContext, LanguageSeeder.EnumerateSeeds());

        return System.Threading.Tasks.Task.CompletedTask;
    }

    private static async System.Threading.Tasks.Task SeedAsync<T>(DbContext dbContext, IEnumerable<T> list)
		where T : BaseEntity
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

		if (setAdd)
		{
            _ = await dbContext.SaveChangesAsync();
		}
	}
}
