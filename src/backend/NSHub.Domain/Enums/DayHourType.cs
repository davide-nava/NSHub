// <copyright file="DayHourType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Enums;

/// <summary>
/// Hourly durations across different temporal and calendar units.
/// </summary>

public enum DayHourType
{
    /// <summary>
    /// Single hour unit.
    /// </summary>
    Hour = 1,

    /// <summary>
    /// Daylight transition short day (23 hours).
    /// </summary>
    Legal = 23,

    /// <summary>
    /// Standard calendar day (24 hours).
    /// </summary>
    Day = 24,

    /// <summary>
    /// Daylight transition long day (25 hours).
    /// </summary>
    Solar = 25,

    /// <summary>
    /// Standard calendar year (8760 hours).
    /// </summary>
    Year = 8760,

    /// <summary>
    /// Leap year (8784 hours).
    /// </summary>
    YearLeap = 8784,
}
