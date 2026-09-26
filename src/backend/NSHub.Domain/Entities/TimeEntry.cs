// <copyright file="TimeEntry.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing a work time entry.
/// </summary>
public class TimeEntry : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the employee identifier.
    /// </summary>
    public Guid? EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the work date.
    /// </summary>
    public DateTime WorkDate { get; set; }

    /// <summary>
    /// Gets or sets the clock-in time.
    /// </summary>
    public TimeSpan? StartTime { get; set; }

    /// <summary>
    /// Gets or sets the clock-out time.
    /// </summary>
    public TimeSpan? EndTime { get; set; }

    /// <summary>
    /// Gets or sets the break duration in minutes.
    /// </summary>
    public int? BreakDurationMinutes { get; set; }

    /// <summary>
    /// Gets or sets the total number of worked hours.
    /// </summary>
    public decimal TotalHoursWorked { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the work was performed during night hours.
    /// </summary>
    public bool IsNightWork { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the work was performed on Sunday.
    /// </summary>
    public bool IsSundayWork { get; set; }

    /// <summary>
    /// Gets or sets additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets the UTC clock-in date and time.
    /// </summary>
    public DateTime ClockInUtc => WorkDate.Date + (StartTime ?? TimeSpan.Zero);

    /// <summary>
    /// Gets the UTC clock-out date and time.
    /// </summary>
    public DateTime? ClockOutUtc => EndTime.HasValue ? WorkDate.Date + EndTime.Value : null;
}
