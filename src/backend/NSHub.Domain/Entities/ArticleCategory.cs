// <copyright file="ArticleCategory.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an article category.
/// </summary>
public class ArticleCategory : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the category code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the category description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the articles associated with this category.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> Articles { get; set; } = [];
}
