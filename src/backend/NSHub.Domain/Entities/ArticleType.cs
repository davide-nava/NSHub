// <copyright file="ArticleType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ArticleType : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    private readonly List<Article> _articles = new();
    public virtual IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();

    protected ArticleType() { }

    public static ArticleType Create()
    {
        return new ArticleType();
    }
}
