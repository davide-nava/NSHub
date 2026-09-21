// <copyright file="UserRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Infrastructure.Identity.Persistence.Repositories;

using Microsoft.EntityFrameworkCore;
using NSHub.Domain.Identity.Entities;
using NSHub.Domain.Identity.Repositories;
using NSHub.Domain.Identity.ValueObjects;
using NSHub.Infrastructure.Persistence;

/// <summary>
/// EF Core implementation of <see cref="IUserRepository"/>.
/// </summary>
public class UserRepository(OpenXGestDbContext context) : IUserRepository
{
    /// <inheritdoc />
    public async Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default)
    {
        return await context.Set<User>()
            .Include(u => u.Roles)
            .Include(u => u.Claims)
            .FirstOrDefaultAsync(u => u.Id == id, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();
        return await context.Set<User>()
            .Include(u => u.Roles)
            .Include(u => u.Claims)
            .FirstOrDefaultAsync(u => u.Email == normalizedEmail, cancellationToken);
    }

    /// <inheritdoc />
    public async Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default)
    {
        var normalizedEmail = email.Trim().ToLowerInvariant();
        return await context.Set<User>()
            .AnyAsync(u => u.Email == normalizedEmail, cancellationToken);
    }

    /// <inheritdoc />
    public async Task AddAsync(User user, CancellationToken cancellationToken = default)
    {
        _ = await context.Set<User>().AddAsync(user, cancellationToken);
    }

    /// <inheritdoc />
    public void Update(User user)
    {
        if (context.Entry(user).State == EntityState.Detached)
        {
            _ = context.Set<User>().Attach(user);
        }

        context.Entry(user).State = EntityState.Modified;
    }
}
