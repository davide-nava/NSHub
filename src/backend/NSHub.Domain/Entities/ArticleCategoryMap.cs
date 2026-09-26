// <copyright file="ArticleCategoryMap.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ArticleCategoryMap : AuditableTenantEntity
{
    public Guid ArticleId { get; protected set; }
    public Guid ArticleCategoryId { get; protected set; }
    public virtual Article? Article { get; protected set; }
    public virtual ArticleCategory? ArticleCategory { get; protected set; }

    protected ArticleCategoryMap() { }

    public static ArticleCategoryMap Create()
    {
        return new ArticleCategoryMap();
    }
}
