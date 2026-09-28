// <copyright file="IReadRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using NSHub.Domain.Common;

namespace NSHub.Application.Common.Interfaces.Repositories;

/// <summary>
/// Read-only repository interface for querying auditable entities with optional predicates and pagination.
/// </summary>
/// <typeparam name="TEntity">The type of the auditable entity.</typeparam>
public interface IReadRepository<TEntity> where TEntity : AuditableEntity
{
    /// <summary>
    /// Retrieves an entity by its unique identifier.
    /// </summary>
    /// <param name="id">The unique identifier of the entity.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the entity if found; otherwise, <see langword="null"/>.</returns>
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves all entities matching an optional predicate.
    /// </summary>
    /// <param name="predicate">An optional filter predicate.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the collection of matching entities.</returns>
    Task<IReadOnlyList<TEntity>> GetListAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default);

    /// <summary>
    /// Determines whether any entity satisfies the specified condition.
    /// </summary>
    /// <param name="predicate">The condition to test.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing <see langword="true"/> if any entity satisfies the condition; otherwise, <see langword="false"/>.</returns>
    Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellationToken = default);

    /// <summary>
    /// Returns the total count of entities matching an optional predicate.
    /// </summary>
    /// <param name="predicate">An optional filter predicate.</param>
    /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
    /// <returns>A task that represents the asynchronous operation, containing the total count of matching entities.</returns>
    Task<int> CountAsync(Expression<Func<TEntity, bool>>? predicate = null, CancellationToken cancellationToken = default);
}
