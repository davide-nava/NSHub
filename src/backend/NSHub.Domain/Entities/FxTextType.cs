// <copyright file="FxTextType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

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
