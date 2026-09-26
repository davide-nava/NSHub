// <copyright file="IAuditableEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Domain.Common;

/// <summary>
/// Defines an entity that can be audited for changes, including creation, deletion, and updates.
/// </summary>
public interface IAuditableEntity : ISoftDeletable
{
    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was inserted.
    /// </summary>
    public DateTime DateInsert { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    public DateTime DateUpdate { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who inserted the entity.
    /// </summary>
    public Guid? UserInsertId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who last updated the entity.
    /// </summary>
    public Guid? UserUpdateId { get; set; }

    /// <summary>
    /// Gets or sets the user who inserted the entity.
    /// </summary>
    public User? UserInsert { get; set; }

    /// <summary>
    /// Gets or sets the user who last updated the entity.
    /// </summary>
    public User? UserUpdate { get; set; }
}
