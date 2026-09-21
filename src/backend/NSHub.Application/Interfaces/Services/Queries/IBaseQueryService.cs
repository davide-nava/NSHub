// <copyright file="IBaseQueryService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.PlanetHub.Models;
using NSHub.Application.PlanetHub.Models.EntityModels;

namespace NSHub.Application.Interfaces.Services.Queries;

public interface IBaseQueryService<TModel>
    where TModel : BaseEntityModel
{
    Task<IEnumerable<LookupModel>?> LookupAsync(CancellationToken cancellationToken = default);

    Task<IEnumerable<TModel>?> ListAsync(PaginationModel paginationModel, CancellationToken cancellationToken = default);

    Task<TModel?> GetAsync(Guid id, CancellationToken cancellationToken = default);

    Task<int> CountAsync(CancellationToken cancellationToken = default);
}

