// <copyright file="CountryLookup.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a country lookup entity.
/// </summary>
public class CountryLookup
{
    /// <summary>Gets or sets the country code (Primary Key).</summary>
    public string CodCountry { get; set; } = null!;

    /// <summary>Gets or sets the description/name.</summary>
    public string? Description { get; set; }

    /// <summary>Gets or sets the abbreviation/code acronym.</summary>
    public string? Acronym { get; set; }

    /// <summary>Gets or sets the language code.</summary>
    public string? CodLanguage { get; set; }
}
