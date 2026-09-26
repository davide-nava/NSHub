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
    /// Gets the parent brand identifier.
    /// Used for hierarchical brand structures.
    /// </summary>
    public Guid? ArticleBrandId { get; protected set; }

    /// <summary>
    /// Gets the brand code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the brand description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;


    /// <summary>
    /// Gets the articles associated with this brand.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> Articles { get; set; } = [];

    /// <summary>
    /// Gets the parent brand.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ArticleBrand? ParentArticleBrand { get; set; }

    /// <summary>
    /// Gets the child brands.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<ArticleBrand> ChildArticleBrands { get; set; } = [];
}
