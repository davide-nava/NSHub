// <copyright file="IDateTimeProvider.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Common.Interfaces;

/// <summary>
/// Abstraction for system date and time operations, supporting Swiss legal timezone conversions.
/// </summary>
public interface IDateTimeProvider
{
    /// <summary>
    /// Gets the current date and time in UTC.
    /// </summary>
    DateTime UtcNow { get; }

    /// <summary>
    /// Gets the current date in UTC, with the time component set to 00:00:00.
    /// </summary>
    DateTime TodayUtc { get; }

    /// <summary>
    /// Converts a UTC date and time to Swiss legal time, considering daylight saving time adjustments.
    /// </summary>
    /// <param name="utcDateTime">The UTC date and time to convert.</param>
    /// <returns>The converted Swiss legal time.</returns>
    DateTime ToSwissTime(DateTime utcDateTime);

    /// <summary>
    /// Converts a Swiss legal date and time to UTC, considering daylight saving time adjustments.
    /// </summary>
    /// <param name="swissDateTime">The Swiss legal date and time to convert.</param>
    /// <returns>The converted UTC date and time.</returns>
    DateTime ToUtc(DateTime swissDateTime);
}
