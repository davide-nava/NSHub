// <copyright file="BaseEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Represents the abstract base entity providing a unique identifier and domain event management capabilities.
/// </summary>
public class BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    public DateTime DateUpdate { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the date and time when the entity was inserted.
    /// </summary>
    public DateTime DateInsert { get; set; } = DateTime.UtcNow;

    /// <summary>
    /// Gets or sets the date and time when the entity was deleted.
    /// </summary>
    public DateTime? DateDeleted { get; set; } = DateTime.UtcNow;

    /// <summary>
    ///  Gets or sets the user identifier who inserted the entity.
    /// </summary>
    public Guid UserInsertId
    {
        get; set;
    }

    /// <summary>
    ///  Gets or sets the user identifier who updated the entity.
    /// </summary>
    public Guid UserUpdateId
    {
        get; set;
    }
}
