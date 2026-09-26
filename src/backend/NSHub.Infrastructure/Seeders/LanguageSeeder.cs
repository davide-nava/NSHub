// <copyright file="LanguageSeeder.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Constants;
using NSHub.Domain.Entities;

namespace NSHub.Infrastructure.Seeders;

/// <summary>
/// Provides default seed data for supported languages.
/// </summary>
public static class LanguageSeeder
{
    private static readonly (Guid Id, string Code, string Description)[] Seeds =
    [
        (LanguageConstant.Italian.Id, LanguageConstant.Italian.Name, "Italian"),
        (LanguageConstant.English.Id, LanguageConstant.English.Name, "English"),
        (LanguageConstant.French.Id, LanguageConstant.French.Name, "French"),
        (LanguageConstant.German.Id, LanguageConstant.German.Name, "German"),
    ];

    /// <summary>
    /// Enumerates the default seed languages.
    /// </summary>
    /// <returns>A sequence of <see cref="Language"/> instances.</returns>
    public static IEnumerable<Language> EnumerateSeeds()
    {
        return Seeds.Select(s => new Language
        {
            Id = s.Id,
            Code = s.Code,
            Description = s.Description,
        });
    }
}
