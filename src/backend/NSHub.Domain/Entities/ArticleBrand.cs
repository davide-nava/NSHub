using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ArticleBrand : AuditableTenantEntity
{
    public Guid? ArticleBrandId { get; protected set; }
    public string Code { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    private readonly List<Article> _articles = new();
    public virtual IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();

    protected ArticleBrand() { }

    public static ArticleBrand Create()
    {
        return new ArticleBrand();
    }
}
