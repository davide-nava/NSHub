// <copyright file="ArticleGroupMap.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents the association between an article and a group.
/// </summary>
public class ArticleGroupMap : AuditableTenantEntity
{
    /// <summary>
    /// Gets the article identifier.
    /// </summary>
    public Guid ArticleId { get; protected set; }

    /// <summary>
    /// Gets the article group identifier.
    /// </summary>
    public Guid ArticleGroupId { get; protected set; }

    /// <summary>
    /// Gets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; protected set; }

    /// <summary>
    /// Gets the associated article group.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ArticleGroup? ArticleGroup { get; protected set; }
}
