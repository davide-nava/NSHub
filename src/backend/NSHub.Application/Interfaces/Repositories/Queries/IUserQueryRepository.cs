// <copyright file="IUserQueryRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Entities.Json;

namespace NSHub.Application.Interfaces.Repositories.Queries;

public interface IUserQueryRepository : IBaseQueryRepository<User>
{
    Task<UserConfigurationJson?> GetUserConfigurationAsync(CancellationToken cancellationToken = default);

    Task<User?> GetUserLoggedAsync(CancellationToken cancellationToken = default);
}
