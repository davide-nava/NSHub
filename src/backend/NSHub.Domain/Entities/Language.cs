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
    private readonly List<DncText> _dncTexts = [];
    private readonly List<FxText> _fxTexts = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="Language"/> class.
    /// </summary>
    public Language()
    {
    }

    /// <summary>
    /// Gets or sets the language code (e.g. "it", "en", "de", "fr").
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the descriptive name of the language.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the collection of DNC texts associated with this language.
    /// </summary>
    public virtual IReadOnlyCollection<DncText> DncTexts => _dncTexts.AsReadOnly();

    /// <summary>
    /// Gets the collection of FX texts associated with this language.
    /// </summary>
    public virtual IReadOnlyCollection<FxText> FxTexts => _fxTexts.AsReadOnly();

    /// <summary>
    /// Factory method to create a new language instance.
    /// </summary>
    /// <returns>A new <see cref="Language"/> instance.</returns>
    public static Language Create()
    {
        return new Language();
    }
}
