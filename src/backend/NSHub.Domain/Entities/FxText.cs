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
    /// Gets or sets the FX text number.
    /// </summary>
    public string? Number { get; set; }

    /// <summary>
    /// Gets or sets the FX text description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the language identifier.
    /// </summary>
    public Guid LanguageId { get; set; }

    /// <summary>
    /// Gets or sets the FX text type identifier.
    /// </summary>
    public Guid FxTextTypeId { get; set; }

    /// <summary>
    /// Gets or sets the insertion date.
    /// </summary>
    public DateTime InsertionDate { get; set; }

    /// <summary>
    /// Gets or sets the associated FX text type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual FxTextType? FxTextType { get; set; }

    /// <summary>
    /// Gets or sets the associated language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Language? Language { get; set; }
}
