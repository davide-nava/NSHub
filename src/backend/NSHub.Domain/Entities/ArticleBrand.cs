// <copyright file="ArticleBrand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an article brand.
/// </summary>
public class ArticleBrand : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the parent brand identifier.
    /// Used for hierarchical brand structures.
    /// </summary>
    public Guid? ArticleBrandId { get; set; }

    /// <summary>
    /// Gets or sets the brand code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the brand description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the articles associated with this brand.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> Articles { get; set; } = [];

    /// <summary>
    /// Gets or sets the parent brand.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ArticleBrand? ParentArticleBrand { get; set; }

    /// <summary>
    /// Gets or sets the child brands.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<ArticleBrand> ChildArticleBrands { get; set; } = [];
}
