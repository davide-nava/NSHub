// <copyright file="CurrencyConstant.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Models;

namespace NSHub.Domain.Constants;

/// <summary>
/// Provides predefined currency values and utility methods for currency validation and retrieval.
/// </summary>
public static class CurrencyConstant
{
    /// <summary>
    /// The collection of supported currencies.
    /// </summary>
    private static readonly List<ConstantValue> Currencies =
    [
        Chf,
        Eur,
    ];

    /// <summary>
    /// Gets the Swiss Franc (CHF) currency definition.
    /// </summary>
    public static ConstantValue Chf => new()
    {
        Id = new Guid(0xC8734C8A, 0x5E7D, 0x4DD7, 0x9F, 0x66, 0x37, 0xBB, 0x50, 0x9D, 0xB3, 0xC8) /* C8734C8A-5E7D-4DD7-9F66-37BB509DB3C8 */,
        Name = "chf",
        Index = 1,
    };

    /// <summary>
    /// Gets the Euro (EUR) currency definition.
    /// </summary>
    public static ConstantValue Eur => new()
    {
        Id = new Guid(0xBEAE3795, 0x821, 0x48D9, 0x97, 0xB0, 0x47, 0x4F, 0x23, 0xB9, 0x85, 0x8A) /* BEAE3795-0821-48D9-97B0-474F23B9858A */,
        Name = "eur",
        Index = 2,
    };

    /// <summary>
    /// Determines whether the specified currency identifier exists.
    /// </summary>
    /// <param name="id">The currency identifier to validate.</param>
    /// <returns>
    /// <see langword="true"/> if the currency identifier exists; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public static bool CheckId(Guid id) => Currencies.Exists(e => e.Id == id);

    /// <summary>
    /// Determines whether the specified currency name exists.
    /// </summary>
    /// <param name="name">The currency name to validate.</param>
    /// <returns>
    /// <see langword="true"/> if the currency name exists; otherwise,
    /// <see langword="false"/>.
    /// </returns>
    public static bool CheckName(string name) => Currencies.Exists(e => string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Returns the currency associated with the specified name, or the default currency (CHF)
    /// when no matching currency is found.
    /// </summary>
    /// <param name="name">The currency name.</param>
    /// <returns>
    /// The matching <see cref="ConstantValue"/> instance, or the default currency.
    /// </returns>
    public static ConstantValue CheckOrDefaultName(string name) =>
        !CheckName(name)
            ? Chf
            : Currencies.First(e => string.Equals(e.Name, name, StringComparison.OrdinalIgnoreCase));

    /// <summary>
    /// Returns the currency associated with the specified identifier, or the default currency (CHF)
    /// when no matching currency is found.
    /// </summary>
    /// <param name="id">The currency identifier.</param>
    /// <returns>
    /// The matching <see cref="ConstantValue"/> instance, or the default currency.
    /// </returns>
    public static ConstantValue CheckOrDefaultId(Guid id) =>
        !CheckId(id)
            ? Chf
            : Currencies.First(e => e.Id == id);
}
