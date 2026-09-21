// <copyright file="GetTimesheetQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.Extensions.Localization;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Features.TimeTracking.Mapping;
using NSHub.Application.Resources;
using NSHub.Domain.Common;
using NSHub.Domain.Services;

namespace NSHub.Application.Features.TimeTracking.Queries.GetTimesheet;

/// <summary>
/// MediatR request handler for computing and projecting employee timesheets.
/// </summary>
public class GetTimesheetQueryHandler(
    IEmployeeRepository employeeRepository,
    ITimeEntryRepository timeEntryRepository,
    IDateTimeProvider dateTimeProvider,
    IStringLocalizer<ValidationMessages> localizer) : IRequestHandler<GetTimesheetQuery, Result<TimesheetDto>>
{
    private readonly SwissWorktimePolicy policy = new SwissWorktimePolicy();

    public async Task<Result<TimesheetDto>> Handle(GetTimesheetQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
        if (employee == null)
        {
            return Result<TimesheetDto>.Failure(Error.NotFound("Employee.NotFound", localizer["EmployeeNotFound"]));
        }

        var entries = await timeEntryRepository.GetEntriesForEmployeeRangeAsync(
            request.EmployeeId,
            request.StartDateUtc,
            request.EndDateUtc,
            cancellationToken);

        // Group punches by Swiss local calendar date
        var groupedByDate = entries
            .GroupBy(e => dateTimeProvider.ToSwissTime(e.ClockInUtc).Date)
            .OrderBy(g => g.Key);

        var days = new List<DaySummaryDto>();
        double totalNet = 0;
        double totalNight = 0;
        double totalSunday = 0;
        var totalRestViolations = 0;
        var totalAmplitudeViolations = 0;

        foreach (var group in groupedByDate)
        {
            var date = group.Key;
            double dayGross = 0;
            var dayBreak = 0;
            double dayNet = 0;
            double dayNight = 0;
            double daySunday = 0;
            var hasRestViolation = false;
            var hasAmplitudeViolation = false;

            var entryDtos = new List<TimeEntryDto>();

            foreach (var entry in group.OrderBy(e => e.ClockInUtc))
            {
                if (entry.ClockOutUtc.HasValue)
                {
                    var gross = (entry.ClockOutUtc.Value - entry.ClockInUtc).TotalHours;
                    var net = gross - (entry.BreakDurationMinutes / 60.0);
                    dayGross += gross;
                    dayBreak += entry.BreakDurationMinutes;
                    dayNet += Math.Max(0, net);

                    dayNight += policy.CalculateNightHours(entry.ClockInUtc, entry.ClockOutUtc.Value);
                    daySunday += policy.CalculateSundayHours(entry.ClockInUtc, entry.ClockOutUtc.Value);
                }

                if (entry.DailyRestPeriodViolated)
                {
                    hasRestViolation = true;
                    totalRestViolations++;
                }

                if (entry.DailyAmplitudeExceeded)
                {
                    hasAmplitudeViolation = true;
                    totalAmplitudeViolations++;
                }

                entryDtos.Add(entry.ToDto(dateTimeProvider));
            }

            // Calculation of daily statutory breakdown
            var dailyContractual = employee.ContractualWeeklyHours / 5.0m;
            var dailyBreakdown = policy.SplitWorkHours((decimal)dayNet, dailyContractual, employee.StatutoryWeeklyLimit);

            totalNet += dayNet;
            totalNight += dayNight;
            totalSunday += daySunday;

            days.Add(new DaySummaryDto(
                date,
                date.ToString("yyyy-MM-dd"),
                Math.Round(dayGross, 2),
                dayBreak,
                Math.Round(dayNet, 2),
                (double)dailyBreakdown.OrdinaryHours,
                (double)dailyBreakdown.SupplementaryHours,
                (double)dailyBreakdown.StatutoryOvertimeHours,
                Math.Round(dayNight, 2),
                Math.Round(daySunday, 2),
                hasRestViolation,
                hasAmplitudeViolation,
                entryDtos
            ));
        }

        // Global period breakdown
        var periodBreakdown = policy.SplitWorkHours(
            (decimal)totalNet,
            employee.ContractualWeeklyHours,
            employee.StatutoryWeeklyLimit);

        var dto = new TimesheetDto(
            employee.Id,
            $"{employee.FirstName} {employee.LastName}",
            employee.Oll1Regime,
            employee.ContractualWeeklyHours,
            employee.StatutoryWeeklyLimit,
            request.StartDateUtc,
            request.EndDateUtc,
            Math.Round(totalNet, 2),
            (double)periodBreakdown.OrdinaryHours,
            (double)periodBreakdown.SupplementaryHours,
            (double)periodBreakdown.StatutoryOvertimeHours,
            Math.Round(totalNight, 2),
            Math.Round(totalSunday, 2),
            totalRestViolations,
            totalAmplitudeViolations,
            days
        );

        return Result<TimesheetDto>.Success(dto);
    }
}
