// <copyright file="IUserCommandRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities.Json;
using NSHub.Application.PlanetHub.Models.EntityModels;

namespace NSHub.Application.Interfaces.Repositories.Commands;

public interface IUserCommandRepository : IBaseCommandRepository<UserModel>
{
    Task<UserConfigurationJson?> SetConfigurationAsync(UserConfigurationJson entity, Guid userId,  CancellationToken cancellationToken = default);
}

