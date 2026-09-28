// <copyright file="HourType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Operational classifications for hour types.
/// </summary>
public enum HourType
{
    /// <summary>
    /// Standard contractual normal hour.
    /// </summary>
    Normal = 0,

    /// <summary>
    /// Solar / daylight saving extended hour.
    /// </summary>
    Solar = 10,

    /// <summary>
    /// Statutory legal hour.
    /// </summary>
    Legal = 3,
}
