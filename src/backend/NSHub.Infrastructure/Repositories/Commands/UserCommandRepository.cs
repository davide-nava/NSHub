// <copyright file="UserCommandRepository.cs" company="Progel SA">
// Copyright (c) Progel SA. All rights reserved.
// </copyright>

using Microsoft.EntityFrameworkCore;

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Entities.Json;
using NSHub.ApplicationCore.Interfaces.Repositories.Commands;
using NSHub.Caches.Interfaces;
using NSHub.Infrastructure.DbContexts;

namespace NSHub.Infrastructure.Repositories.Commands;

public class UserCommandRepository(TenantDbContext dbContext, INSHubMemoryCacheService? nSHubMemoryCacheService = null) : BaseCommandRepository<User>(dbContext, nSHubMemoryCacheService), IUserCommandRepository
{
    public async Task<UserConfigurationJson?> SetConfigurationAsync(UserConfigurationJson entity, Guid userId, CancellationToken cancellationToken = default)
    {
        ArgumentNullException.ThrowIfNull(entity);

        nSHubMemoryCacheService?.RemoveContainsKey("User_");

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
