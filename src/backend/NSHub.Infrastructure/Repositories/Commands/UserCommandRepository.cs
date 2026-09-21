// <copyright file="UserCommandRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.ApplicationCore.Entities.Json;
using PlanetHub.ApplicationCore.Interfaces.Repositories.Commands;
using PlanetHub.Caches.Interfaces;
using PlanetHub.Infrastructure.DbContexts;

namespace PlanetHub.Infrastructure.Repositories.Commands;

public class UserCommandRepository(TenantDbContext dbContext, IPlanetHubMemoryCacheService? planetHubMemoryCacheService = null) : BaseCommandRepository<User>(dbContext, planetHubMemoryCacheService), IUserCommandRepository
{
    public async Task<UserConfigurationJson?> SetConfigurationAsync(UserConfigurationJson entity, Guid userId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        planetHubMemoryCacheService?.RemoveContainsKey("User_");

        var tmpUser = await dbContext.Users.FirstOrDefaultAsync(x => x.Id == userId, cancellationToken);

        if (tmpUser == null)
        {
            return null;
        }

        tmpUser.Configuration = entity;

        await dbContext.SaveChangesAsync(cancellationToken);

        return await dbContext.Users.AsNoTracking().Where(x => x.Id == userId).Select(e => e.Configuration).FirstOrDefaultAsync(cancellationToken);
    }
}
