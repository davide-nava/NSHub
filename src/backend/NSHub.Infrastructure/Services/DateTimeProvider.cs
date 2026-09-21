// <copyright file="DateTimeProvider.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Application.Common.Interfaces;

namespace NSHub.Infrastructure.Services;

/// <summary>
/// Provides current date and time values with Swiss timezone conversion utilities.
/// </summary>
public class DateTimeProvider : IDateTimeProvider
{
    private static readonly TimeZoneInfo SwissTimeZone = GetSwissTimeZone();

    private static TimeZoneInfo GetSwissTimeZone()
    {
        try
        {
            return TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
        }
        catch
        {
            try
            {
                return TimeZoneInfo.FindSystemTimeZoneById("Europe/Zurich");
            }
            catch
            {
                return TimeZoneInfo.Utc;
            }
        }
    }

    /// <inheritdoc/>
    public DateTime UtcNow => DateTime.UtcNow;

    /// <inheritdoc/>
    public DateTime SwissNow => TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, SwissTimeZone);

    /// <inheritdoc/>
    public DateTime ToSwissTime(DateTime utcDateTime)
    {
        var utc = DateTime.SpecifyKind(utcDateTime, DateTimeKind.Utc);
        return TimeZoneInfo.ConvertTimeFromUtc(utc, SwissTimeZone);
    }

    /// <inheritdoc/>
    public DateTime ToUtc(DateTime swissDateTime)
    {
        return TimeZoneInfo.ConvertTimeToUtc(swissDateTime, SwissTimeZone);
    }
}
