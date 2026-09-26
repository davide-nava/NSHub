using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class UnitOfMeasure : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;
    public string Code { get; protected set; } = string.Empty;

    private readonly List<Article> _articles = new();
    public virtual IReadOnlyCollection<Article> Articles => _articles.AsReadOnly();

    protected UnitOfMeasure() { }

    public static UnitOfMeasure Create()
    {
        return new UnitOfMeasure();
    }
}
