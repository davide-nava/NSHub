// <copyright file="IUserCommandService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities.Json;
using NSHub.Application.PlanetHub.Models.EntityModels;

namespace NSHub.Application.Interfaces.Services.Commands;

public interface IUserCommandService : IBaseCommandService< UserModel>
{
    Task<UserConfigurationJson?> SetConfigurationAsync(UserConfigurationJson entity, Guid userId, CancellationToken cancellationToken = default);
}

