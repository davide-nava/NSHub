// <copyright file="ITenantQueryRespository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;

namespace NSHub.Application.Interfaces.Repositories.Queries;

public interface ITenantQueryRespository : IBaseQueryRepository<Tenant>
{
    Task<IEnumerable<string>> GetConnectionStringAsync(CancellationToken cancellationToken = default);

    Task<string> GetConnectionStringAsync(Guid id, CancellationToken cancellationToken = default);
}
