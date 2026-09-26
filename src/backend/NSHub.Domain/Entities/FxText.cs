// <copyright file="FxText.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class FxText : AuditableTenantEntity
{
    public string? Number { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public Guid LanguageId { get; protected set; }
    public Guid FxTextTypeId { get; protected set; }
    public DateTime InsertionDate { get; protected set; }
    public virtual FxTextType? FxTextType { get; protected set; }
    public virtual Language? Language { get; protected set; }

    protected FxText() { }

    public static FxText Create()
    {
        return new FxText();
    }
}
