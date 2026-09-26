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
    /// Gets the group code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the group description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the group number.
    /// </summary>
    public string Number { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the image path or URL associated with the group.
    /// </summary>
    public string Image { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the articles associated with this group.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> Articles { get; protected set; } = [];
}
