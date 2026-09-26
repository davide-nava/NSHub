// <copyright file="TimeEntry.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;
using NSHub.Domain.Enums;

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing a work time entry.
/// </summary>
public class TimeEntry : AuditableTenantEntity
{
    public Guid? EmployeeId { get; set; }
    public DateTime WorkDate { get; set; }
    public TimeSpan? StartTime { get; set; }
    public TimeSpan? EndTime { get; set; }
    public int? BreakDurationMinutes { get; set; }
    public decimal TotalHoursWorked { get; set; }
    public bool IsNightWork { get; set; }
    public bool IsSundayWork { get; set; }
    public string? Notes { get; set; }
    public TimeEntryStatus Status { get; set; } = TimeEntryStatus.Active;
    public ViolationType Violations { get; set; }
    public virtual Employee? Employee { get; set; }

    public DateTime ClockInUtc => WorkDate.Date + (StartTime ?? TimeSpan.Zero);
    public DateTime? ClockOutUtc => EndTime.HasValue ? WorkDate.Date + EndTime.Value : null;

    public static TimeEntry Create(
        Guid employeeId,
        DateTime clockInUtc,
        string? notes = null)
    {
        return new TimeEntry
        {
            Id = Guid.NewGuid(),
            EmployeeId = employeeId,
            WorkDate = clockInUtc.Date,
            StartTime = clockInUtc.TimeOfDay,
            Status = TimeEntryStatus.Active,
            Notes = notes,
        };
    }

    public void ClockOut(DateTime clockOutUtc, int breakDurationMinutes)
    {
        var endTime = clockOutUtc.TimeOfDay;
        EndTime = endTime;
        BreakDurationMinutes = breakDurationMinutes;
        Status = TimeEntryStatus.Completed;

        var start = StartTime ?? TimeSpan.Zero;
        var totalMinutes = (endTime - start).TotalMinutes - breakDurationMinutes;
        TotalHoursWorked = (decimal)Math.Max(0, totalMinutes / 60.0);
    }
}
