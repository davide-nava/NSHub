// <copyright file="IMapper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.PlanetHub.Models.EntityModels;

namespace NSHub.Application.Interfaces;

public interface IMapper<TEntity, TModel>
    where TEntity : BaseEntity
    where TModel : BaseEntityModel
{
    TModel ToModel(TEntity entity);

    TEntity ToEntity(TModel model);

    IEnumerable<TModel> ToModels(IEnumerable<TEntity> entities);

    IEnumerable<TEntity> ToEntities(IEnumerable<TModel> dtos);

    void UpdateEntity(TModel model, TEntity entity);

}

