// <copyright file="UserRole.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Identity.ValueObjects;

namespace NSHub.Domain.Identity.Entities;

/// <summary>
/// Association between a user and an assigned security role.
/// </summary>
public class UserRole
{
    /// <summary>
    /// Gets the user identifier.
    /// </summary>
    public UserId UserId { get; private set; }

    /// <summary>
    /// Gets the assigned role identifier.
    /// </summary>
    public RoleId RoleId { get; private set; }

    /// <summary>
    /// Gets the UTC timestamp when the role was granted.
    /// </summary>
    public DateTime AssignedAtUtc { get; private set; }

    // Parameterless constructor for EF Core
    private UserRole()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="UserRole"/> class.
    /// </summary>
    /// <param name="userId">The user identifier.</param>
    /// <param name="roleId">The role identifier.</param>
    public UserRole(UserId userId, RoleId roleId)
    {
        UserId = userId;
        RoleId = roleId;
        AssignedAtUtc = DateTime.UtcNow;
    }
}
