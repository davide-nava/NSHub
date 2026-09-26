// <copyright file="ArticleType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an article type.
/// </summary>
public class ArticleType : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the article type code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the article type description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the articles associated with this type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> Articles { get; set; }
        = [];
}
