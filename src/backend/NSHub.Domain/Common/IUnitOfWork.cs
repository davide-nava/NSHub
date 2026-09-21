// <copyright file="IUnitOfWork.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Unit of Work contract ensuring transactional consistency across aggregates.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Commits all pending changes to the underlying storage atomically.
    /// </summary>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The number of state entries written to the database.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
