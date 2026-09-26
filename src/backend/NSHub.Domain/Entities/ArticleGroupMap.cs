using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ArticleGroupMap : AuditableTenantEntity
{
    public Guid ArticleId { get; protected set; }
    public Guid ArticleGroupId { get; protected set; }
    public virtual Article? Article { get; protected set; }
    public virtual ArticleGroup? ArticleGroup { get; protected set; }

    protected ArticleGroupMap() { }

    public static ArticleGroupMap Create()
    {
        return new ArticleGroupMap();
    }
}
