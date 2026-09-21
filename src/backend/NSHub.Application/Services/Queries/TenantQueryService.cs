// <copyright file="TenantQueryService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Interfaces;
using NSHub.Application.Interfaces.Repositories.Queries;
using NSHub.Application.Interfaces.Services.Queries;
using NSHub.Application.PlanetHub.Models.EntityModels;

namespace NSHub.Application.Services.Queries;

public class TenantQueryService(ITenantQueryRespository repo, IMapper<Tenant, TenantModel> mapper) : BaseQueryService<Tenant, TenantModel, ITenantQueryRespository>(repo,  mapper), ITenantQueryService
{
    public async Task<IEnumerable<string>> GetConnectionStringAsync(CancellationToken cancellationToken = default) => await repo.GetConnectionStringAsync(cancellationToken);

    public async Task<string> GetConnectionStringAsync(Guid id, CancellationToken cancellationToken = default) => await repo.GetConnectionStringAsync(id, cancellationToken);
}

