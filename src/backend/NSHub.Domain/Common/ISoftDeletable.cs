// <copyright file="ISoftDeletable.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;

namespace NSHub.Domain.Common;

/// <summary>
/// Defines an entity that can be soft deleted.
/// </summary>
public interface ISoftDeletable
{
    /// <summary>
    /// Gets or sets the date and time when the entity was soft deleted.
    /// </summary>
    public DateTime? DateDelete { get; set; }

    /// <summary>
    /// Gets or sets the ID of the user who soft deleted the entity.
    /// </summary>
    public Guid? UserDeleteId { get; set; }

    /// <summary>
    /// Gets or sets the user who soft deleted the entity.
    /// </summary>
    public User? UserDelete { get; set; }
}
