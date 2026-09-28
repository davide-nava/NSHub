// <copyright file="Oll1RegimeType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Represents the type of OLL1 regime.
/// </summary>
public enum Oll1RegimeType
{
    /// <summary>
    /// Represents the standard OLL1 regime (Art. 73).
    /// </summary>
    StandardArt73 = 1,

    /// <summary>
    /// Represents the simplified OLL1 regime (Art. 73a).
    /// </summary>
    SimplifiedArt73a = 2,

    /// <summary>
    /// Represents the opt-out OLL1 regime (Art. 73b).
    /// </summary>
    OptOutArt73b = 3,
}
