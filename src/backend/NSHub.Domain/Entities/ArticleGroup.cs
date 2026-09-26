using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ArticleGroup : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;
    public string Number { get; protected set; } = string.Empty;
    public string Image { get; protected set; } = string.Empty;

    private readonly List<ArticleGroupMap> _articleGroupMaps = new();
    public virtual IReadOnlyCollection<ArticleGroupMap> ArticleGroupMaps => _articleGroupMaps.AsReadOnly();
    private readonly List<ArticleMachine> _articleMachines = new();
    public virtual IReadOnlyCollection<ArticleMachine> ArticleMachines => _articleMachines.AsReadOnly();

    protected ArticleGroup() { }

    public static ArticleGroup Create()
    {
        return new ArticleGroup();
    }
}
