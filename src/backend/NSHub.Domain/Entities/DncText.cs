// <copyright file="DncText.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class DncText : AuditableTenantEntity
{
    public Guid LanguageId { get; protected set; }
    public string Number { get; protected set; } = string.Empty;
    public string Text { get; protected set; } = string.Empty;
    public virtual Language? Language { get; protected set; }

    protected DncText() { }

    public static DncText Create()
    {
        return new DncText();
    }
}
