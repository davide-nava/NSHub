// <copyright file="ArticleCategoryMap.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents the association between an article and a category.
/// </summary>
public class ArticleCategoryMap : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the article identifier.
    /// </summary>
    public Guid ArticleId { get; set; }

    /// <summary>
    /// Gets or sets the category identifier.
    /// </summary>
    public Guid ArticleCategoryId { get; set; }

    /// <summary>
    /// Gets or sets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; set; }

    /// <summary>
    /// Gets or sets the associated category.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ArticleCategory? ArticleCategory { get; set; }
}
