// <copyright file="TimeEntry.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;
using NSHub.Domain.Enums;
using NSHub.Domain.ValueObjects;

namespace NSHub.Domain.Entities;

/// <summary>
/// Aggregate root representing a working time record compliant with Swiss Labor Law (LL art. 46, OLL 1 art. 73).
/// </summary>
public class TimeEntry : BaseEntity, IAggregateRoot
{
    private readonly List<TimeCorrectionAudit> _auditTrail = [];

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeEntry"/> class.
    /// Required by Entity Framework Core.
    /// </summary>
    protected TimeEntry()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="TimeEntry"/> class.
    /// </summary>
    /// <param name="id">The unique identifier of the time entry.</param>
    /// <param name="employeeId">The associated employee identifier.</param>
    /// <param name="clockInUtc">The UTC timestamp of the clock-in.</param>
    /// <param name="punctualGps">Optional punctual GPS coordinates at clock-in.</param>
    /// <param name="notes">Optional notes associated with the entry.</param>
    /// <exception cref="ArgumentException">Thrown when employeeId is empty.</exception>
    public TimeEntry(
        Guid id,
        Guid employeeId,
        DateTime clockInUtc,
        GpsCoordinate? punctualGps = null,
        string? notes = null)
    {
        if (employeeId == Guid.Empty)
        {
            throw new ArgumentException("Employee identifier is mandatory.", nameof(employeeId));
        }

        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        EmployeeId = employeeId;
        ClockInUtc = clockInUtc;
        PunctualClockInGps = punctualGps;
        Notes = notes;
        BreakDurationMinutes = 0;
        Status = TimeEntryStatus.Open;
        Violations = ViolationType.None;
    }

    /// <summary>
    /// Gets the unique identifier of the employee.
    /// </summary>
    public Guid EmployeeId { get; private set; }

    /// <summary>
    /// Gets the UTC timestamp when the employee clocked in.
    /// </summary>
    public DateTime ClockInUtc { get; private set; }

    /// <summary>
    /// Gets the UTC timestamp when the employee clocked out, or null if the shift is active.
    /// </summary>
    public DateTime? ClockOutUtc { get; private set; }

    /// <summary>
    /// Gets the total break duration taken during the shift in minutes.
    /// </summary>
    public int BreakDurationMinutes { get; private set; }

    /// <summary>
    /// Gets punctual GPS coordinates recorded at the moment of clock-in (no continuous tracking).
    /// </summary>
    public GpsCoordinate? PunctualClockInGps { get; private set; }

    /// <summary>
    /// Gets punctual GPS coordinates recorded at the moment of clock-out (no continuous tracking).
    /// </summary>
    public GpsCoordinate? PunctualClockOutGps { get; private set; }

    /// <summary>
    /// Gets consecutive rest hours elapsed between the previous shift end and this shift start.
    /// </summary>
    public double? RestPeriodHoursBeforeShift { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the statutory minimum daily rest period of 11 consecutive hours was violated (Art. 15a LL / Art. 19 OLL 1).
    /// </summary>
    public bool DailyRestPeriodViolated { get; private set; }

    /// <summary>
    /// Gets the total daily amplitude of the working day in hours (span from first start to final finish including breaks).
    /// </summary>
    public double? DailyAmplitudeHours { get; private set; }

    /// <summary>
    /// Gets a value indicating whether the statutory maximum daily amplitude of 14 hours was exceeded (Art. 10 LL / Art. 13 OLL 1).
    /// </summary>
    public bool DailyAmplitudeExceeded { get; private set; }

    /// <summary>
    /// Gets optional notes attached to this time entry.
    /// </summary>
    public string? Notes { get; private set; }

    /// <summary>
    /// Gets the current operational status of the time entry.
    /// </summary>
    public TimeEntryStatus Status { get; private set; }

    /// <summary>
    /// Gets the statutory labor compliance violations detected for this entry.
    /// </summary>
    public ViolationType Violations { get; private set; }

    /// <summary>
    /// Gets the read-only audit trail collection of corrections made to this entry.
    /// </summary>
    public IReadOnlyCollection<TimeCorrectionAudit> AuditTrail => _auditTrail.AsReadOnly();

    /// <summary>
    /// Records a clock-out event for this shift, validating consistency and calculating totals.
    /// </summary>
    /// <param name="clockOutUtc">The UTC timestamp of clock-out.</param>
    /// <param name="breakDurationMinutes">The duration of breaks in minutes.</param>
    /// <param name="punctualGps">Optional punctual GPS coordinates at clock-out.</param>
    /// <returns>A result indicating success or validation failure.</returns>
    public Result ClockOut(DateTime clockOutUtc, int breakDurationMinutes, GpsCoordinate? punctualGps = null)
    {
        if (clockOutUtc <= ClockInUtc)
        {
            return Result.Failure(Error.Validation("TimeEntry.InvalidClockOut", "Clock-out timestamp cannot precede or equal clock-in timestamp."));
        }

        if (breakDurationMinutes < 0)
        {
            return Result.Failure(Error.Validation("TimeEntry.NegativeBreak", "Break duration cannot be negative."));
        }

        var totalMinutes = (clockOutUtc - ClockInUtc).TotalMinutes;
        if (breakDurationMinutes >= totalMinutes)
        {
            return Result.Failure(Error.Validation("TimeEntry.BreakExceedsDuration", "Break duration cannot exceed overall shift duration."));
        }

        ClockOutUtc = clockOutUtc;
        BreakDurationMinutes = breakDurationMinutes;
        PunctualClockOutGps = punctualGps;
        Status = TimeEntryStatus.Completed;

        return Result.Success();
    }

    /// <summary>
    /// Sets the compliance metrics calculated according to Swiss statutory labor regulations.
    /// </summary>
    /// <param name="restHours">Consecutive rest hours preceding this shift.</param>
    /// <param name="restViolated">Whether the 11-hour rest period was violated.</param>
    /// <param name="amplitudeHours">The daily work amplitude in hours.</param>
    /// <param name="amplitudeExceeded">Whether the 14-hour daily amplitude was exceeded.</param>
    /// <param name="violations">Aggregated violation flags.</param>
    public void SetComplianceMetrics(
        double? restHours,
        bool restViolated,
        double? amplitudeHours,
        bool amplitudeExceeded,
        ViolationType violations)
    {
        RestPeriodHoursBeforeShift = restHours;
        DailyRestPeriodViolated = restViolated;
        DailyAmplitudeHours = amplitudeHours;
        DailyAmplitudeExceeded = amplitudeExceeded;
        Violations = violations;
    }

    /// <summary>
    /// Applies an audit-tracked correction to clock-in, clock-out, or break duration compliant with Art. 73 OLL 1.
    /// </summary>
    /// <param name="operatorId">The identifier of the operator applying the correction.</param>
    /// <param name="newClockInUtc">The corrected clock-in UTC timestamp.</param>
    /// <param name="newClockOutUtc">The corrected clock-out UTC timestamp.</param>
    /// <param name="newBreakMinutes">The corrected break duration in minutes.</param>
    /// <param name="mandatoryReason">Mandatory justification reason required by Swiss labor law.</param>
    /// <param name="ipAddress">Optional IP address of the operator.</param>
    /// <returns>A result containing the created audit record or a validation failure.</returns>
    public Result<TimeCorrectionAudit> ApplyCorrection(
        Guid operatorId,
        DateTime newClockInUtc,
        DateTime? newClockOutUtc,
        int newBreakMinutes,
        string mandatoryReason,
        string? ipAddress = null)
    {
        if (string.IsNullOrWhiteSpace(mandatoryReason))
        {
            return Result<TimeCorrectionAudit>.Failure(Error.Validation("TimeCorrection.ReasonRequired", "Correction reason is mandatory by statutory Swiss labor law (Art. 73 OLL 1)."));
        }

        if (newClockOutUtc.HasValue && newClockOutUtc.Value <= newClockInUtc)
        {
            return Result<TimeCorrectionAudit>.Failure(Error.Validation("TimeCorrection.InvalidDates", "Corrected clock-out timestamp cannot precede or equal clock-in timestamp."));
        }

        var audit = new TimeCorrectionAudit(
            Guid.NewGuid(),
            Id,
            operatorId,
            DateTime.UtcNow,
            ClockInUtc,
            ClockOutUtc,
            BreakDurationMinutes,
            newClockInUtc,
            newClockOutUtc,
            newBreakMinutes,
            mandatoryReason.Trim(),
            ipAddress);

        _auditTrail.Add(audit);

        ClockInUtc = newClockInUtc;
        ClockOutUtc = newClockOutUtc;
        BreakDurationMinutes = newBreakMinutes;
        Status = TimeEntryStatus.Approved;

        return Result<TimeCorrectionAudit>.Success(audit);
    }
}
