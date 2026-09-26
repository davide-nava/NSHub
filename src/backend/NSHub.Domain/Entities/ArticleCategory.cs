using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ArticleCategory : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    private readonly List<Article> _articles = new();
    public virtual IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();
    private readonly List<ArticleCategoryMap> _articleCategoryMaps = new();
    public virtual IReadOnlyCollection<ArticleCategoryMap> ArticleCategoryMaps => _articleCategoryMaps.AsReadOnly();

    protected ArticleCategory() { }

    public static ArticleCategory Create()
    {
        return new ArticleCategory();
    }
}
