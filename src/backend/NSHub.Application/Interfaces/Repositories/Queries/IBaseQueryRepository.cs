// <copyright file="IBaseQueryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.NSHub.Models;

namespace NSHub.Application.Interfaces.Repositories.Queries;

public interface IBaseQueryRepository<TEntity>
    where TEntity : BaseEntity
{
    Task<IEnumerable<LookupModel>?> LookupAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<TEntity>?> ListAsync(PaginationModel paginationModel, CancellationToken cancellationToken = default);

    Task<TEntity?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);
}
