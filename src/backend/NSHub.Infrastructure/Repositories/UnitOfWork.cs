// <copyright file="UnitOfWork.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Infrastructure.DbContexts;

namespace NSHub.Infrastructure.Repositories;

/// <summary>
/// Entity Framework Core implementation of <see cref="IUnitOfWork"/>.
/// </summary>
/// <param name="dbContext">The application database context.</param>
public class UnitOfWork(ApplicationDbContext dbContext) : IUnitOfWork
{
    /// <inheritdoc/>
    public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return dbContext.SaveChangesAsync(cancellationToken);
    }
}
