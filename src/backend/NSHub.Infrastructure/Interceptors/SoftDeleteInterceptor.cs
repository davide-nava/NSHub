// <copyright file="SoftDeleteInterceptor.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using NSHub.Application.Interfaces;

namespace NSHub.Infrastructure.Interceptors;

public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
{
	public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
		DbContextEventData eventData,
		InterceptionResult<int> result,
		CancellationToken cancellationToken = default)
	{
		ArgumentNullException.ThrowIfNull(eventData);
		if (eventData.Context is null)
		{
			return base.SavingChangesAsync(
				eventData, result, cancellationToken);
		}

		foreach (var softDeletable in eventData.Context.ChangeTracker.Entries<ISoftDeletable>().Where(e => e.State == EntityState.Deleted))
		{
			softDeletable.State = EntityState.Modified;
			softDeletable.Entity.IsDeleted = true;
			softDeletable.Entity.DateDeleted = DateTime.UtcNow;
		}

		return base.SavingChangesAsync(eventData, result, cancellationToken);
	}
}
