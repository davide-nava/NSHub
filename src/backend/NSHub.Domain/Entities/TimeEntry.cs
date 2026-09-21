// <copyright file="TimeEntry.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;
using NSHub.Domain.Enums;
using NSHub.Domain.ValueObjects;

namespace NSHub.Domain.Entities;

/// <summary>
/// Aggregate Root rappresentante una timbratura di presenza conforme alla Legge sul lavoro svizzera (LL art. 46, OLL 1 art. 73).
/// </summary>
public class TimeEntry : BaseEntity, IAggregateRoot
{
    public Guid EmployeeId { get; private set; }
    public DateTime ClockInUtc { get; private set; }
    public DateTime? ClockOutUtc { get; private set; }
    public int BreakDurationMinutes { get; private set; }

    /// <summary>
    /// Coordinate GPS puntuali rilevate al momento della timbratura di entrata (nessun tracciamento continuo).
    /// </summary>
    public GpsCoordinate? PunctualClockInGps { get; private set; }

    /// <summary>
    /// Coordinate GPS puntuali rilevate al momento della timbratura di uscita (nessun tracciamento continuo).
    /// </summary>
    public GpsCoordinate? PunctualClockOutGps { get; private set; }

    // Indicatori di conformità al Diritto del Lavoro Svizzero
    /// <summary>
    /// Ore di riposo continuativo intercorse tra la fine del turno precedente e l'inizio del presente turno.
    /// </summary>
    public double? RestPeriodHoursBeforeShift { get; private set; }

    /// <summary>
    /// Flag di violazione del riposo giornaliero minimo di 11 ore consecutive (Art. 15a LL / Art. 19 OLL 1).
    /// </summary>
    public bool DailyRestPeriodViolated { get; private set; }

    /// <summary>
    /// Ampiezza totale della giornata lavorativa in ore (intervallo tra il primo inizio e l'ultimo termine compreso pause).
    /// </summary>
    public double? DailyAmplitudeHours { get; private set; }

    /// <summary>
    /// Flag di superamento dell'ampiezza massima consentita di 14 ore giornaliere (Art. 10 LL / Art. 13 OLL 1).
    /// </summary>
    public bool DailyAmplitudeExceeded { get; private set; }

    public string? Notes { get; private set; }
    public TimeEntryStatus Status { get; private set; }
    public ViolationType Violations { get; private set; }

    private readonly List<TimeCorrectionAudit> _auditTrail = [];
    public IReadOnlyCollection<TimeCorrectionAudit> AuditTrail => _auditTrail.AsReadOnly();

    protected TimeEntry() { }

    public TimeEntry(
        Guid id,
        Guid employeeId,
        DateTime clockInUtc,
        GpsCoordinate? punctualGps = null,
        string? notes = null)
    {
        if (employeeId == Guid.Empty)
            throw new ArgumentException("Employee identifier is mandatory.", nameof(employeeId));

        Id = id == Guid.Empty ? Guid.NewGuid() : id;
        EmployeeId = employeeId;
        ClockInUtc = clockInUtc;
        PunctualClockInGps = punctualGps;
        Notes = notes;
        BreakDurationMinutes = 0;
        Status = TimeEntryStatus.OPEN;
        Violations = ViolationType.NONE;
    }

    public Result ClockOut(DateTime clockOutUtc, int breakDurationMinutes, GpsCoordinate? punctualGps = null)
    {
        if (clockOutUtc <= ClockInUtc)
            return Result.Failure(Error.Validation("TimeEntry.InvalidClockOut", "Clock-out timestamp cannot precede or equal clock-in timestamp."));

        if (breakDurationMinutes < 0)
            return Result.Failure(Error.Validation("TimeEntry.NegativeBreak", "Break duration cannot be negative."));

        var totalMinutes = (clockOutUtc - ClockInUtc).TotalMinutes;
        if (breakDurationMinutes >= totalMinutes)
            return Result.Failure(Error.Validation("TimeEntry.BreakExceedsDuration", "Break duration cannot exceed overall shift duration."));

        ClockOutUtc = clockOutUtc;
        BreakDurationMinutes = breakDurationMinutes;
        PunctualClockOutGps = punctualGps;
        Status = TimeEntryStatus.COMPLETED;

        return Result.Success();
    }

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

    public Result<TimeCorrectionAudit> ApplyCorrection(
        Guid operatorId,
        DateTime newClockInUtc,
        DateTime? newClockOutUtc,
        int newBreakMinutes,
        string mandatoryReason,
        string? ipAddress = null)
    {
        if (string.IsNullOrWhiteSpace(mandatoryReason))
            return Result<TimeCorrectionAudit>.Failure(Error.Validation("TimeCorrection.ReasonRequired", "Correction reason is mandatory by statutory Swiss labor law (Art. 73 OLL 1)."));

        if (newClockOutUtc.HasValue && newClockOutUtc.Value <= newClockInUtc)
            return Result<TimeCorrectionAudit>.Failure(Error.Validation("TimeCorrection.InvalidDates", "Corrected clock-out timestamp cannot precede or equal clock-in timestamp."));

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
        Status = TimeEntryStatus.APPROVED;

        return Result<TimeCorrectionAudit>.Success(audit);
    }
}
