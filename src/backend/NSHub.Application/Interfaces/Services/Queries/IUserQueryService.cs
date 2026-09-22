// <copyright file="IUserQueryService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities.Json;
using NSHub.Application.NSHub.Models.EntityModels;

namespace NSHub.Application.Interfaces.Services.Queries;

public interface IUserQueryService : IBaseQueryService<UserModel>
{
    Task<UserConfigurationJson?> GetUserConfigurationAsync(CancellationToken cancellationToken = default);

    Task<UserModel?> GetUserLoggedAsync(Guid userId, Guid tenantId, CancellationToken cancellationToken = default);
}

