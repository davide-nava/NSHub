// <copyright file="Language.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing a supported natural language.
/// </summary>
public class Language : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the language code (e.g. "it", "en", "de", "fr").
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the descriptive name of the language.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the DNC texts associated with this language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<DncText> DncTexts { get; protected set; }
        = new List<DncText>();

    /// <summary>
    /// Gets the dressing configuration 1 translations associated with this language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<DressingName1> DressingName1s { get; protected set; }
        = new List<DressingName1>();

    /// <summary>
    /// Gets the dressing configuration 2 translations associated with this language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<DressingName2> DressingName2s { get; protected set; }
        = new List<DressingName2>();

    /// <summary>
    /// Gets the dressing configuration 3 translations associated with this language.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<DressingName3> DressingName3s { get; protected set; }
        = new List<DressingName3>();
}
