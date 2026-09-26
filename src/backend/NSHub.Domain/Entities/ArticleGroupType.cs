using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ArticleGroupType : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;
    public string? ProductionOrder { get; protected set; }

    protected ArticleGroupType() { }

    public static ArticleGroupType Create()
    {
        return new ArticleGroupType();
    }
}
