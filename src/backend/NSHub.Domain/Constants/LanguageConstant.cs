// <copyright file="LanguageConstant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Models;

namespace NSHub.Domain.Constants;

/// <summary>
/// Provides predefined language values and utility methods for language validation and retrieval.
/// </summary>
public static class LanguageConstant
{
    /// <summary>
    /// The collection of supported languages.
    /// </summary>
    private static readonly List<ConstantValue> Languages =
    [
        English,
        Italian,
        French,
        German,
    ];

    /// <summary>
    /// Gets the English language definition.
    /// </summary>
    public static ConstantValue English => new()
    {
        Id = new Guid(0xC7FAF0BA, 0xF47C, 0x4FBB, 0xB4, 0x1E, 0x9E, 0x9, 0xEC, 0xD3, 0x3A, 0xB9) /* C7FAF0BA-F47C-4FBB-B41E-9E09ECD33AB9 */,
        Name = "en",
        Index = 1,
    };

    /// <summary>
    /// Gets the Italian language definition.
    /// </summary>
    public static ConstantValue Italian => new()
    {
        Id = new Guid(0x691AA257, 0xE222, 0x4CA0, 0x92, 0xD3, 0x7E, 0xB3, 0x63, 0x8D, 0x48, 0x38) /* 691AA257-E222-4CA0-92D3-7EB3638D4838 */,
        Name = "it",
        Index = 2,
    };

    /// <summary>
    /// Gets the French language definition.
    /// </summary>
    public static ConstantValue French => new()
    {
        Id = new Guid(0xEC310AF, 0x6488, 0x4ED8, 0xA8, 0x63, 0x6A, 0xDF, 0x4A, 0x7, 0x8E, 0xBF) /* 0EC310AF-6488-4ED8-A863-6ADF4A078EBF */,
        Name = "fr",
        Index = 3,
    };

    /// <summary>
    /// Gets the German language definition.
    /// </summary>
    public static ConstantValue German => new()
    {
        Id = new Guid(0x7C0EF1F3, 0xED01, 0x4CFE, 0x89, 0xB2, 0x9, 0x2D, 0x30, 0xFA, 0x6C, 0x5) /* 7C0EF1F3-ED01-4CFE-89B2-092D30FA6C05 */,
        Name = "de",
        Index = 4,
    };

    /// <summary>
    /// Determines whether the specified language identifier exists.
    /// </summary>
    /// <param name="id">The language identifier to validate.</param>
    /// <returns>
    /// <see langword="true"/> if the language identifier exists; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public static bool CheckId(Guid id) => Languages.Exists(e => e.Id == id);

    /// <summary>
    /// Determines whether the specified language code exists.
    /// </summary>
    /// <param name="name">The language code to validate.</param>
    /// <returns>
    /// <see langword="true"/> if the language code exists; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public static bool CheckName(string name) => Languages.Exists(e => string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Returns the language associated with the specified code, or the default language (Italian)
    /// when no matching language is found.
    /// </summary>
    /// <param name="name">The language code.</param>
    /// <returns>
    /// The matching <see cref="ConstantValue"/> instance, or the default language.
    /// </returns>
    public static ConstantValue CheckOrDefaultName(string name) =>
        !CheckName(name)
            ? Italian
            : Languages.First(e => string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Returns the language associated with the specified identifier, or the default language (Italian)
    /// when no matching language is found.
    /// </summary>
    /// <param name="id">The language identifier.</param>
    /// <returns>
    /// The matching <see cref="ConstantValue"/> instance, or the default language.
    /// </returns>
    public static ConstantValue CheckOrDefaultId(Guid id) =>
        !CheckId(id)
            ? Italian
            : Languages.First(e => e.Id == id);
}
