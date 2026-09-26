// <copyright file="IDateTimeService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;

namespace NSHub.Application.Common.Interfaces;

/// <summary>
/// Abstraction for accessing current date and time.
/// </summary>
public interface IDateTimeService
{
    /// <summary>
    /// Gets the current local date and time.
    /// </summary>
    DateTime Now { get; }

    /// <summary>
    /// Gets the current UTC date and time.
    /// </summary>
    DateTime UtcNow { get; }

    /// <summary>
    /// Converts a UTC date and time to Swiss local time.
    /// </summary>
    /// <param name="utc">The UTC timestamp.</param>
    /// <returns>The Swiss local date and time.</returns>
    DateTime ToSwissTime(DateTime utc);
}
