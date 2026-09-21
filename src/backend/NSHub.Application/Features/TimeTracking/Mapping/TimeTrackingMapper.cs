// <copyright file="TimeTrackingMapper.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

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
    /// <param name="dateTimeProvider">The date and time provider for timezone conversions.</param>
    /// <returns>A populated <see cref="TimeEntryDto"/> instance.</returns>
    public static TimeEntryDto ToDto(this TimeEntry entry, IDateTimeProvider dateTimeProvider)
    {
        var endUtc = entry.ClockOutUtc ?? dateTimeProvider.UtcNow;
        var totalMinutes = (endUtc - entry.ClockInUtc).TotalMinutes;
        var netMinutes = Math.Max(0, totalMinutes - entry.BreakDurationMinutes);
        var netWorkedHours = Math.Round(netMinutes / 60.0, 2);

        return new TimeEntryDto(
            entry.Id,
            entry.EmployeeId,
            entry.ClockInUtc,
            entry.ClockOutUtc,
            dateTimeProvider.ToSwissTime(entry.ClockInUtc),
            entry.ClockOutUtc.HasValue ? dateTimeProvider.ToSwissTime(entry.ClockOutUtc.Value) : null,
            entry.BreakDurationMinutes,
            netWorkedHours,
            entry.PunctualClockInGps != null,
            entry.PunctualClockOutGps != null,
            entry.RestPeriodHoursBeforeShift,
            entry.DailyRestPeriodViolated,
            entry.DailyAmplitudeHours,
            entry.DailyAmplitudeExceeded,
            entry.Notes,
            entry.Status,
            entry.Violations,
            entry.AuditTrail.Select(a => new TimeCorrectionAuditDto(
                a.Id,
                a.OperatorId,
                a.TimestampUtc,
                a.PreCorrectionClockInUtc,
                a.PreCorrectionClockOutUtc,
                a.PreCorrectionBreakMinutes,
                a.PostCorrectionClockInUtc,
                a.PostCorrectionClockOutUtc,
                a.PostCorrectionBreakMinutes,
                a.MandatoryReason
            )).ToList()
        );
    }
}
