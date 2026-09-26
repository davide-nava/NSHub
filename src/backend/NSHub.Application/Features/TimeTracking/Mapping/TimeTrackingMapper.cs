// <copyright file="TimeTrackingMapper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.TimeTracking.Mapping;

/// <summary>
/// Mapping extension methods for time-tracking domain entities.
/// </summary>
public static class TimeTrackingMapper
{
    /// <summary>
    /// Maps a <see cref="TimeEntry"/> domain entity to a <see cref="TimeEntryDto"/>.
    /// </summary>
    /// <param name="entry">The time entry entity.</param>
    /// <param name="dateTimeService">The date and time service for timezone conversions.</param>
    /// <returns>A populated <see cref="TimeEntryDto"/> instance.</returns>
    public static TimeEntryDto ToDto(this TimeEntry entry, IDateTimeService dateTimeService)
    {
        var endUtc = entry.ClockOutUtc ?? dateTimeService.UtcNow;
        var totalMinutes = (endUtc - entry.ClockInUtc).TotalMinutes;
        var breakMinutes = entry.BreakDurationMinutes ?? 0;
        var netMinutes = Math.Max(0, totalMinutes - breakMinutes);
        var netWorkedHours = Math.Round(netMinutes / 60.0, 2);

        return new TimeEntryDto(
            entry.Id,
            entry.EmployeeId ?? Guid.Empty,
            entry.ClockInUtc,
            entry.ClockOutUtc,
            dateTimeService.ToSwissTime(entry.ClockInUtc),
            entry.ClockOutUtc.HasValue ? dateTimeService.ToSwissTime(entry.ClockOutUtc.Value) : null,
            breakMinutes,
            netWorkedHours,
            false,
            false,
            null,
            false,
            null,
            false,
            entry.Notes,
            entry.Status,
            entry.Violations,
            new List<TimeCorrectionAuditDto>()
        );
    }
}
