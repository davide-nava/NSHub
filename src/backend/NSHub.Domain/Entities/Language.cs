// <copyright file="Language.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a language entity.
/// </summary>
public class Language : BaseLookup
{
    /// <summary>Gets or sets the abbreviation/code acronym.</summary>

    /// <summary>Gets or sets the language code.</summary>
    public string? CodLanguage { get; set; }
}
