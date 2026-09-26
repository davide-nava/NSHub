using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Language : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string Description { get; protected set; } = string.Empty;

    private readonly List<DncText> _dncTexts = new();
    public virtual IReadOnlyCollection<DncText> DncTexts => _dncTexts.AsReadOnly();
    private readonly List<FxText> _fxTexts = new();
    public virtual IReadOnlyCollection<FxText> FxTexts => _fxTexts.AsReadOnly();

    protected Language() { }

    public static Language Create()
    {
        return new Language();
    }
}
