// <copyright file="Role.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;
using NSHub.Domain.Identity.ValueObjects;

namespace NSHub.Domain.Identity.Entities;

/// <summary>
/// Security role entity defining authorization boundaries.
/// </summary>
public class Role : Entity<RoleId>
{
    /// <summary>
    /// Gets the unique normalized role name.
    /// </summary>
    public string Name { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the role description.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    // Parameterless constructor for EF Core
    private Role()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="Role"/> class.
    /// </summary>
    /// <param name="id">The role identifier.</param>
    /// <param name="name">The role name.</param>
    /// <param name="description">The role description.</param>
    public Role(RoleId id, string name, string description = "")
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Role name cannot be empty.", nameof(name));
        }

        Id = id;
        Name = name.Trim().ToUpperInvariant();
        Description = description.Trim();
    }
}
