// <copyright file="Oll1Regime.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

using System.Text.Json.Serialization;

/// <summary>
/// Working time recording regimes defined under Ordinance 1 to the Swiss Employment Act (ArGV 1 / OLL 1).
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum Oll1Regime
{
    /// <summary>
    /// Standard full recording of working hours including start time, rest breaks, and end time (Art. 73 ArGV 1 / OLL 1).
    /// </summary>
    StandardRecord = 1,

    /// <summary>
    /// Simplified recording of total daily working hours without tracking detailed start and end timestamps (Art. 73a ArGV 1 / OLL 1).
    /// Applicable to employees possessing significant autonomy in scheduling their daily work.
    /// </summary>
    SimplifiedRecord = 2,

    /// <summary>
    /// Waiver of working time recording (Art. 73b ArGV 1 / OLL 1).
    /// Applicable to executive staff and specialized professionals whose gross annual salary exceeds CHF 120,000.
    /// </summary>
    OptOut = 3,
}
