// <copyright file="ArticleGroup.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a group of articles.
/// </summary>
public class ArticleGroup : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the group code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the group description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the group number.
    /// </summary>
    public string Number { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the image path or URL associated with the group.
    /// </summary>
    public string Image { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the articles associated with this group.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> Articles { get; set; } = [];
}
