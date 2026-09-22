// <copyright file="IBaseCommandRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Defines the contract for command operations on an entity repository.
/// </summary>
/// <typeparam name="TEntity">The entity type managed by the repository.</typeparam>
public interface IBaseCommandRepository<TEntity>
    where TEntity : BaseEntity
{
    /// <summary>
    /// Adds a new entity to the repository.
    /// </summary>
    /// <param name="entity">The entity to add.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Updates an existing entity in the repository.
    /// </summary>
    /// <param name="entity">The entity to update.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Deletes an existing entity from the repository.
    /// </summary>
    /// <param name="id">The ID of the entity to delete.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A <see cref="Task"/> representing the asynchronous operation.</returns>
    public Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}
