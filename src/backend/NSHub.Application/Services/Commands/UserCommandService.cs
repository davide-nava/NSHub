// <copyright file="UserCommandService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Entities;
using NSHub.Application.Entities.Json;
using NSHub.Application.Interfaces;
using NSHub.Application.Interfaces.Repositories.Commands;
using NSHub.Application.Interfaces.Services.Commands;
using NSHub.Application.NSHub.Models.EntityModels;

namespace NSHub.Application.Services.Commands;

public class UserCommandService(IUserCommandRepository repo, IMapper<User, UserModel> mapper) : BaseCommandService<User, UserModel, IUserCommandRepository>(repo, mapper), IUserCommandService
{
    public async Task<UserConfigurationJson?> SetConfigurationAsync(UserConfigurationJson entity, Guid userId,  CancellationToken cancellationToken = default) => await repo.SetConfigurationAsync(entity, userId, cancellationToken);
}
