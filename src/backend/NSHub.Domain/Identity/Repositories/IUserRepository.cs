// <copyright file="IUserRepository.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Identity.Repositories;

using NSHub.Domain.Identity.Entities;
using NSHub.Domain.Identity.ValueObjects;

/// <summary>
/// Repository contract for managing user aggregate persistence.
/// </summary>
public interface IUserRepository
{
    /// <summary>
    /// Retrieves a user by their strongly-typed identifier.
    /// </summary>
    Task<User?> GetByIdAsync(UserId id, CancellationToken cancellationToken = default);

    /// <summary>
    /// Retrieves a user by their unique email address.
    /// </summary>
    Task<User?> GetByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Checks whether an account exists with the specified email address.
    /// </summary>
    Task<bool> ExistsByEmailAsync(string email, CancellationToken cancellationToken = default);

    /// <summary>
    /// Adds a new user aggregate to the repository.
    /// </summary>
    Task AddAsync(User user, CancellationToken cancellationToken = default);

    /// <summary>
    /// Marks the user aggregate as modified.
    /// </summary>
    void Update(User user);
}
