// <copyright file="ReadRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Domain.Common;
using NSHub.Infrastructure.DbContexts;

namespace NSHub.Infrastructure.Repositories;

/// <summary>
/// Generic Entity Framework Core read-only repository implementation for auditable entities.
/// </summary>
/// <typeparam name="TEntity">The type of the auditable entity.</typeparam>
/// <param name="dbContext">The application database context.</param>
public class ReadRepository<TEntity>(ApplicationDbContext dbContext) : IReadRepository<TEntity>
    where TEntity : AuditableEntity
{
    /// <summary>
    /// Gets the underlying database context.
    /// </summary>
    protected ApplicationDbContext DbContext { get; } = dbContext;

    /// <summary>
    /// Gets the entity database set with no-tracking query behavior.
    /// </summary>
    protected IQueryable<TEntity> Query => DbContext.Set<TEntity>().AsNoTracking();

    /// <inheritdoc/>
    public virtual async Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return await Query.FirstOrDefaultAsync(e => e.Id == id, cancellationToken);
    }

    /// <inheritdoc/>
    public virtual async Task<IReadOnlyList<TEntity>> GetListAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        var query = Query;
        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await query.ToListAsync(cancellationToken);
    }

    /// <inheritdoc/>
    public virtual async Task<bool> AnyAsync(
        Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(predicate);
        return await Query.AnyAsync(predicate, cancellationToken);
    }

    /// <inheritdoc/>
    public virtual async Task<int> CountAsync(
        Expression<Func<TEntity, bool>>? predicate = null,
        CancellationToken cancellationToken = default)
    {
        var query = Query;
        if (predicate != null)
        {
            query = query.Where(predicate);
        }

        return await query.CountAsync(cancellationToken);
    }
}
