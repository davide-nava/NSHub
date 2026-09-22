// <copyright file="ITenantQueryService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.NSHub.Models.EntityModels;

namespace NSHub.Application.Interfaces.Services.Queries;

public interface ITenantQueryService : IBaseQueryService<TenantModel>
{
    Task<IEnumerable<string>> GetConnectionStringAsync(CancellationToken cancellationToken = default);

    Task<string> GetConnectionStringAsync(Guid id, CancellationToken cancellationToken = default);
}

