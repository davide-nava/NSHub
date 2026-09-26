// <copyright file="ArticleGroupType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a type of article group.
/// </summary>
public class ArticleGroupType : AuditableTenantEntity
{
    /// <summary>
    /// Gets the group type code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the group type description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the production order associated with the group type.
    /// </summary>
    public string? ProductionOrder { get; protected set; }

    /// <summary>
    /// Gets the article groups associated with this group type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<ArticleGroup> ArticleGroups { get; protected set; }
        = new List<ArticleGroup>();
}
