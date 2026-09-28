// <copyright file="IUnitOfWork.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Common.Interfaces.Repositories;

/// <summary>
/// Defines the contract for coordinating transactional changes across repositories.
/// </summary>
public interface IUnitOfWork
{
    /// <summary>
    /// Persists all pending changes made in this unit of work to the underlying data store.
    /// </summary>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous save operation, containing the number of state entities written.</returns>
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
