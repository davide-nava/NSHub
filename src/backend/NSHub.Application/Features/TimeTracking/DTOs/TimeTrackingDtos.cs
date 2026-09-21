// <copyright file="TimeTrackingDtos.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Enums;

namespace NSHub.Application.Features.TimeTracking.DTOs;

/// <summary>
/// Data transfer object representing a recorded time entry.
/// </summary>
/// <param name="Id">The unique identifier of the time entry.</param>
/// <param name="EmployeeId">The unique identifier of the employee.</param>
/// <param name="ClockInUtc">The clock-in timestamp in UTC.</param>
/// <param name="ClockOutUtc">The clock-out timestamp in UTC, if closed.</param>
/// <param name="ClockInSwiss">The clock-in timestamp converted to Swiss local time.</param>
/// <param name="ClockOutSwiss">The clock-out timestamp converted to Swiss local time, if closed.</param>
/// <param name="BreakDurationMinutes">The total break duration in minutes.</param>
/// <param name="NetWorkedHours">The net worked hours excluding breaks.</param>
/// <param name="HasClockInGps">A value indicating whether clock-in GPS coordinates are recorded.</param>
/// <param name="HasClockOutGps">A value indicating whether clock-out GPS coordinates are recorded.</param>
/// <param name="RestPeriodHoursBeforeShift">The consecutive rest hours elapsed before this shift.</param>
/// <param name="DailyRestPeriodViolated">A value indicating whether the minimum 11-hour rest period was violated.</param>
/// <param name="DailyAmplitudeHours">The total daily amplitude in hours.</param>
/// <param name="DailyAmplitudeExceeded">A value indicating whether the statutory 14-hour daily amplitude was exceeded.</param>
/// <param name="Notes">Optional notes regarding the shift.</param>
/// <param name="Status">The current lifecycle status of the entry.</param>
/// <param name="Violations">Flags representing detected statutory labor violations.</param>
/// <param name="AuditTrail">The collection of retroactive correction audit log entries.</param>
public record TimeEntryDto(
    Guid Id,
    Guid EmployeeId,
    DateTime ClockInUtc,
    DateTime? ClockOutUtc,
    DateTime ClockInSwiss,
    DateTime? ClockOutSwiss,
    int BreakDurationMinutes,
    double NetWorkedHours,
    bool HasClockInGps,
    bool HasClockOutGps,
    double? RestPeriodHoursBeforeShift,
    bool DailyRestPeriodViolated,
    double? DailyAmplitudeHours,
    bool DailyAmplitudeExceeded,
    string? Notes,
    TimeEntryStatus Status,
    ViolationType Violations,
    List<TimeCorrectionAuditDto> AuditTrail
);

/// <summary>
/// Data transfer object representing a retroactive correction audit trail record.
/// </summary>
/// <param name="Id">The unique identifier of the audit entry.</param>
/// <param name="OperatorId">The operator or user identifier who executed the correction.</param>
/// <param name="TimestampUtc">The timestamp when the correction was performed in UTC.</param>
/// <param name="PreClockInUtc">The original clock-in timestamp in UTC.</param>
/// <param name="PreClockOutUtc">The original clock-out timestamp in UTC.</param>
/// <param name="PreBreakMinutes">The original break duration in minutes.</param>
/// <param name="PostClockInUtc">The modified clock-in timestamp in UTC.</param>
/// <param name="PostClockOutUtc">The modified clock-out timestamp in UTC.</param>
/// <param name="PostBreakMinutes">The modified break duration in minutes.</param>
/// <param name="MandatoryReason">The mandatory justification recorded for the correction.</param>
public record TimeCorrectionAuditDto(
    Guid Id,
    Guid OperatorId,
    DateTime TimestampUtc,
    DateTime PreClockInUtc,
    DateTime? PreClockOutUtc,
    int PreBreakMinutes,
    DateTime PostClockInUtc,
    DateTime? PostClockOutUtc,
    int PostBreakMinutes,
    string MandatoryReason
);

/// <summary>
/// Data transfer object summarizing the current live time-tracking status of an employee.
/// </summary>
/// <param name="EmployeeId">The unique identifier of the employee.</param>
/// <param name="IsClockedIn">A value indicating whether the employee is actively clocked in.</param>
/// <param name="ActiveEntryId">The identifier of the active time entry, if clocked in.</param>
/// <param name="ClockInUtc">The active clock-in timestamp in UTC, if clocked in.</param>
/// <param name="ClockInSwiss">The active clock-in timestamp in Swiss local time, if clocked in.</param>
/// <param name="ElapsedWorkedHoursToday">The total elapsed worked hours today.</param>
/// <param name="SuggestedStatutoryBreakMinutes">The suggested statutory break minutes based on elapsed hours.</param>
/// <param name="Oll1Regime">The Swiss OLL 1 working time recording regime.</param>
/// <param name="EmployeeFullName">The full name of the employee.</param>
public record CurrentTimeStatusDto(
    Guid EmployeeId,
    bool IsClockedIn,
    Guid? ActiveEntryId,
    DateTime? ClockInUtc,
    DateTime? ClockInSwiss,
    double ElapsedWorkedHoursToday,
    int SuggestedStatutoryBreakMinutes,
    Oll1Regime Oll1Regime,
    string EmployeeFullName
);

/// <summary>
/// Data transfer object summarizing recorded worktime and metrics for a specific calendar day.
/// </summary>
/// <param name="Date">The calendar date.</param>
/// <param name="DateFormatted">The ISO 8601 formatted date string.</param>
/// <param name="GrossHours">The total gross shift hours.</param>
/// <param name="TotalBreakMinutes">The total break minutes taken during the day.</param>
/// <param name="NetWorkedHours">The total net worked hours.</param>
/// <param name="OrdinaryHours">The contractual ordinary hours worked.</param>
/// <param name="SupplementaryHours">The supplementary overtime hours (Überstunden).</param>
/// <param name="StatutoryOvertimeHours">The statutory overtime hours exceeding the weekly ceiling (Überzeit).</param>
/// <param name="NightHours">The hours worked during statutory night period.</param>
/// <param name="SundayHours">The hours worked on Sunday.</param>
/// <param name="HasRestViolation">A value indicating whether a daily rest period violation occurred.</param>
/// <param name="HasAmplitudeViolation">A value indicating whether a daily amplitude violation occurred.</param>
/// <param name="Entries">The individual time entries for the day.</param>
public record DaySummaryDto(
    DateTime Date,
    string DateFormatted,
    double GrossHours,
    int TotalBreakMinutes,
    double NetWorkedHours,
    double OrdinaryHours,
    double SupplementaryHours, // Überstunden
    double StatutoryOvertimeHours, // Überzeit
    double NightHours,
    double SundayHours,
    bool HasRestViolation,
    bool HasAmplitudeViolation,
    List<TimeEntryDto> Entries
);

/// <summary>
/// Data transfer object representing an aggregated timesheet for an employee over a period.
/// </summary>
/// <param name="EmployeeId">The employee identifier.</param>
/// <param name="EmployeeName">The employee name.</param>
/// <param name="Oll1Regime">The Swiss OLL 1 working time recording regime.</param>
/// <param name="ContractualWeeklyHours">The contractual weekly hours.</param>
/// <param name="StatutoryWeeklyLimit">The statutory weekly ceiling.</param>
/// <param name="PeriodStartUtc">The beginning of the reporting period in UTC.</param>
/// <param name="PeriodEndUtc">The end of the reporting period in UTC.</param>
/// <param name="TotalNetWorkedHours">The total net worked hours across the period.</param>
/// <param name="TotalOrdinaryHours">The total ordinary hours.</param>
/// <param name="TotalSupplementaryHours">The total supplementary hours (Überstunden).</param>
/// <param name="TotalStatutoryOvertimeHours">The total statutory overtime hours (Überzeit).</param>
/// <param name="TotalNightHours">The total night hours.</param>
/// <param name="TotalSundayHours">The total Sunday hours.</param>
/// <param name="TotalRestViolations">The total count of rest period violations.</param>
/// <param name="TotalAmplitudeViolations">The total count of amplitude violations.</param>
/// <param name="Days">The daily breakdown entries.</param>
public record TimesheetDto(
    Guid EmployeeId,
    string EmployeeName,
    Oll1Regime Oll1Regime,
    decimal ContractualWeeklyHours,
    StatutoryWeeklyLimit StatutoryWeeklyLimit,
    DateTime PeriodStartUtc,
    DateTime PeriodEndUtc,
    double TotalNetWorkedHours,
    double TotalOrdinaryHours,
    double TotalSupplementaryHours, // Überstunden (CO art. 321c)
    double TotalStatutoryOvertimeHours, // Überzeit (LL art. 12/13)
    double TotalNightHours,
    double TotalSundayHours,
    int TotalRestViolations,
    int TotalAmplitudeViolations,
    List<DaySummaryDto> Days
);

/// <summary>
/// Data transfer object encapsulating an exported SECO compliance file.
/// </summary>
/// <param name="FileName">The file name.</param>
/// <param name="ContentType">The MIME content type.</param>
/// <param name="FileBytes">The raw file content bytes.</param>
public record SecoExportDto(
    string FileName,
    string ContentType,
    byte[] FileBytes
);
