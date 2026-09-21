// <copyright file="BaseCommandService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Interfaces;
using NSHub.Application.Interfaces.Repositories.Commands;
using NSHub.Application.Interfaces.Services.Commands;
using NSHub.Application.PlanetHub.Models.EntityModels;

namespace NSHub.Application.Services.Commands;

public class BaseCommandService<TEntity, TModel, TRepository>(TRepository repo,  IMapper<TEntity, TModel> mapper) :
    IBaseCommandService<TModel>
        where TEntity : BaseEntity
        where TModel : BaseEntityModel
        where TRepository : IBaseCommandRepository<TModel>
{
    public async Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var entity = mapper.ToEntity(model);
        _ = await repo.CreateAsync(model, cancellationToken);
        return mapper.ToModel(entity);
    }

    public async Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default)
    {
        var entity = mapper.ToEntity(model);
        _ = await repo.UpdateAsync(model, cancellationToken);
        return mapper.ToModel(entity);
    }

    public async Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default) => await repo.DeleteAsync(id, cancellationToken);

}

