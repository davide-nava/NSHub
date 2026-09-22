// <copyright file="TimeEntry.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;
using NSHub.Domain.Enums;

namespace NSHub.Domain.Entities;

/// <summary>
/// Aggregate root representing a working time record compliant with Swiss Labor Law (LL art. 46, OLL 1 art. 73).
/// </summary>
public class TimeEntry : BaseEntity
{
    /// <summary>
    /// Gets or sets the unique identifier of the employee.
    /// </summary>
    public Guid EmployeeId { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp when the employee clocked in.
    /// </summary>
    public DateTime ClockInUtc { get; set; }

    /// <summary>
    /// Gets or sets the UTC timestamp when the employee clocked out, or null if the shift is active.
    /// </summary>
    public DateTime? ClockOutUtc { get; set; }

    /// <summary>
    /// Gets or sets the total break duration taken during the shift in minutes.
    /// </summary>
    public int BreakDurationMinutes { get; set; }

    /*/// <summary>
    /// Gets punctual GPS coordinates recorded at the moment of clock-in (no continuous tracking).
    /// </summary>
    public GpsCoordinate? PunctualClockInGps { get;  set; }

    /// <summary>
    /// Gets punctual GPS coordinates recorded at the moment of clock-out (no continuous tracking).
    /// </summary>
    public GpsCoordinate? PunctualClockOutGps { get;  set; }*/

    /// <summary>
    /// Gets consecutive rest hours elapsed between the previous shift end and this shift start.
    /// </summary>
    public double? RestPeriodHoursBeforeShift { get; set; }

    /// <summary>
    /// Gets a value indicating whether the statutory minimum daily rest period of 11 consecutive hours was violated (Art. 15a LL / Art. 19 OLL 1).
    /// </summary>
    public bool DailyRestPeriodViolated { get; set; }

    /// <summary>
    /// Gets or sets the total daily amplitude of the working day in hours (span from first start to final finish including breaks).
    /// </summary>
    public double? DailyAmplitudeHours { get; set; }

    /// <summary>
    /// Gets a value indicating whether the statutory maximum daily amplitude of 14 hours was exceeded (Art. 10 LL / Art. 13 OLL 1).
    /// </summary>
    public bool DailyAmplitudeExceeded { get; set; }

    /// <summary>
    /// Gets optional notes attached to this time entry.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the current operational status of the time entry.
    /// </summary>
    public TimeEntryStatus Status { get; set; }

    /// <summary>
    /// Gets or sets the statutory labor compliance violations detected for this entry.
    /// </summary>
    public ViolationType Violations { get; set; }
}
