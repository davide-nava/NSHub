// <copyright file="IBaseCommandService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.PlanetHub.Models.EntityModels;

namespace NSHub.Application.Interfaces.Services.Commands;

public interface IBaseCommandService<TModel>
        where TModel : BaseEntityModel
{
    Task<TModel> CreateAsync(TModel model, CancellationToken cancellationToken = default);

    Task<TModel> UpdateAsync(TModel model, CancellationToken cancellationToken = default);

    Task<int> DeleteAsync(Guid id, CancellationToken cancellationToken = default);
}

