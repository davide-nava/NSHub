// <copyright file="IBaseQueryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Defines the contract for query operations on an entity repository.
/// </summary>
/// <typeparam name="TEntity">The entity type managed by the repository.</typeparam>
public interface IBaseQueryRepository<TEntity>
    where TEntity : BaseEntity
{
    /// <summary>
    /// Retrieves an entity by its ID.
    /// </summary>
    /// <param name="id">The ID of the entity to retrieve.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all entities.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<IEnumerable<TEntity>> ListAsync(CancellationToken cancellationToken = default);
}
