// <copyright file="BaseQueryService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Interfaces;
using NSHub.Application.Interfaces.Repositories.Queries;
using NSHub.Application.Interfaces.Services.Queries;
using NSHub.Application.NSHub.Models;
using NSHub.Application.NSHub.Models.EntityModels;

namespace NSHub.Application.Services.Queries;

public class BaseQueryService<TEntity, TModel, TRepository>(TRepository repo, IMapper<TEntity, TModel> mapper) : IBaseQueryService<TModel>
    where TEntity : BaseEntity
    where TModel : BaseEntityModel
    where TRepository : IBaseQueryRepository<TEntity>
{
    public async Task<int> CountAsync(CancellationToken cancellationToken = default) => await repo.CountAsync(cancellationToken);

    public async Task<TModel?> GetAsync(Guid id, CancellationToken cancellationToken = default)
    {
        var entity = await repo.GetAsync(id, cancellationToken);
        return entity is not null ? mapper.ToModel(entity) : null;
    }

    public async Task<IEnumerable<TModel>?> ListAsync(PaginationModel paginationModel, CancellationToken cancellationToken = default)
    {
        var entities = await repo.ListAsync(paginationModel, cancellationToken);
        return entities is not null ? mapper.ToModels(entities) : null;
    }

    public async Task<IEnumerable<LookupModel>?> LookupAsync(CancellationToken cancellationToken = default) => await repo.LookupAsync(cancellationToken);
}

