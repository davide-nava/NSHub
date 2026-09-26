// <copyright file="FxText.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an FX text.
/// </summary>
public class FxText : AuditableTenantEntity
{
    /// <summary>
    /// Gets the FX text number.
    /// </summary>
    public string? Number { get; protected set; }

    /// <summary>
    /// Gets the FX text description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the language identifier.
    /// </summary>
    public Guid LanguageId { get; protected set; }

    /// <summary>
    /// Gets the FX text type identifier.
    /// </summary>
    public Guid FxTextTypeId { get; protected set; }

    /// <summary>
    /// Gets the insertion date.
    /// </summary>
    public DateTime InsertionDate { get; protected set; }

    /// <summary>
    /// Gets the associated FX text type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual FxTextType? FxTextType { get; protected set; }

    /// <summary>
    /// Gets the associated language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Language? Language { get; protected set; }
}
