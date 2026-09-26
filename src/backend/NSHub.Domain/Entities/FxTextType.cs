using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class FxTextType : AuditableTenantEntity
{
    public string Title { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    private readonly List<FxText> _fxTexts = new();
    public virtual IReadOnlyCollection<FxText> FxTexts => _fxTexts.AsReadOnly();

    protected FxTextType() { }

    public static FxTextType Create()
    {
        return new FxTextType();
    }
}
