// <copyright file="UserQueryService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Entities.Json;
using NSHub.Application.Interfaces;
using NSHub.Application.Interfaces.Repositories.Queries;
using NSHub.Application.Interfaces.Services.Queries;
using NSHub.Application.PlanetHub.Models.EntityModels;

namespace NSHub.Application.Services.Queries;

public class UserQueryService(IUserQueryRepository repo, IMapper<User, UserModel> mapper) : BaseQueryService<User, UserModel, IUserQueryRepository>(repo, mapper), IUserQueryService
{
    public async Task<UserConfigurationJson?> GetUserConfigurationAsync(CancellationToken cancellationToken = default) => await repo.GetUserConfigurationAsync(cancellationToken);

    public async Task<UserModel?> GetUserLoggedAsync(Guid userId, Guid tenantId, CancellationToken cancellationToken = default)
    {
        var entity = await repo.GetUserLoggedAsync(cancellationToken);
        return entity is not null ? mapper.ToModel(entity) : null;
    }
}

