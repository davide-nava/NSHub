// <copyright file="DateTimeService.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using NSHub.Application.Common.Interfaces;

namespace NSHub.Infrastructure.Services;

/// <summary>
/// Service providing system date and time.
/// </summary>
public class DateTimeService : IDateTimeService
{
    private static readonly TimeZoneInfo SwissTimeZone = GetSwissTimeZone();

    /// <inheritdoc/>
    public DateTime Now => DateTime.Now;

    /// <inheritdoc/>
    public DateTime UtcNow => DateTime.UtcNow;

    /// <inheritdoc/>
    public DateTime ToSwissTime(DateTime utc)
    {
        var utcSpecified = DateTime.SpecifyKind(utc, DateTimeKind.Utc);
        return TimeZoneInfo.ConvertTimeFromUtc(utcSpecified, SwissTimeZone);
    }

    private static TimeZoneInfo GetSwissTimeZone()
    {
        try
        {
            return TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time");
        }
        catch (TimeZoneNotFoundException)
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
}
