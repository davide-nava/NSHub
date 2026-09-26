// <copyright file="AuditableEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Domain.Common;

/// <summary>
/// Represents an auditable entity that tracks creation, update, and deletion information.
/// </summary>
public abstract class AuditableEntity : IAuditableEntity, IHasRowVersion
{
    /// <summary>
    /// Gets or sets the date and time when the entity was inserted (created).
    /// </summary>
    public DateTime DateInsert { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was deleted (soft deleted), if applicable.
    /// </summary>
    public DateTime? DateDelete { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    public DateTime DateUpdate { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who inserted (created) the entity.
    /// </summary>
    public Guid? UserInsertId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who deleted (soft deleted) the entity, if applicable.
    /// </summary>
    public Guid? UserDeleteId { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user who last updated the entity.
    /// </summary>
    public Guid? UserUpdateId { get; set; }

    /// <summary>
    /// Gets or sets the row version for concurrency control.
    /// </summary>
    public byte[] RowVersion { get; set; } = [];

    /// <summary>
    /// Gets or sets the user who inserted (created) the entity.
    /// </summary>
    public virtual User? UserInsert { get; set; }

    /// <summary>
    /// Gets or sets the user who last updated the entity.
    /// </summary>
    public virtual User? UserUpdate { get; set; }

    /// <summary>
    /// Gets or sets the user who deleted (soft deleted) the entity, if applicable.
    /// </summary>
    public virtual User? UserDelete { get; set; }
}
