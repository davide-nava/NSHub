// <copyright file="HoursInDayType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

using System.Text.Json.Serialization;

/// <summary>
/// Hour counts representation across normal and daylight saving transition days.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum HoursInDayType
{
    /// <summary>
    /// Not considered.
    /// </summary>
    NotConsidered = 1,

    /// <summary>
    /// Short legal day (23 hours, spring transition).
    /// </summary>
    Legal = 23,

    /// <summary>
    /// Standard calendar day (24 hours).
    /// </summary>
    Normal = 24,

    /// <summary>
    /// Long solar day (25 hours, autumn transition).
    /// </summary>
    Solar = 25,
}
