// <copyright file="LanguageCodeExtensions.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Enums;

namespace NSHub.Domain.Extensions;

/// <summary>
/// Extension methods for <see cref="LanguageCode"/>.
/// </summary>
public static class LanguageCodeExtensions
{
    /// <summary>
    /// Converts a <see cref="LanguageCode"/> to a standard locale code.
    /// </summary>
    /// <param name="lang">The language code enum value.</param>
    /// <returns>The ISO locale string.</returns>
    public static string ToLocaleCode(this LanguageCode lang) => lang switch
    {
        LanguageCode.It => "it-CH",
        LanguageCode.De => "de-CH",
        LanguageCode.Fr => "fr-CH",
        LanguageCode.En => "en-US",
        _ => "it-CH",
    };

    /// <summary>
    /// Parses a language string into a <see cref="LanguageCode"/>.
    /// </summary>
    /// <param name="code">The language code string.</param>
    /// <returns>The resolved <see cref="LanguageCode"/>.</returns>
    public static LanguageCode FromCode(string? code) => code?.ToLowerInvariant() switch
    {
        "de" or "de-ch" or "de-de" => LanguageCode.De,
        "fr" or "fr-ch" or "fr-fr" => LanguageCode.Fr,
        "en" or "en-us" or "en-gb" => LanguageCode.En,
        _ => LanguageCode.It,
    };
}
