// <copyright file="GetTimesheetQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Features.TimeTracking.Mapping;
using NSHub.Domain.Services;

namespace NSHub.Application.Features.TimeTracking.Queries.GetTimesheet;

/// <summary>
/// MediatR request handler for computing and projecting employee timesheets.
/// </summary>
public class GetTimesheetQueryHandler : IRequestHandler<GetTimesheetQuery, Result<TimesheetDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly SwissWorktimePolicy _policy = new();

    public GetTimesheetQueryHandler(IApplicationDbContext context, IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc/>
    public async Task<Result<TimesheetDto>> Handle(GetTimesheetQuery request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == request.EmployeeId, cancellationToken);

        if (employee == null)
        {
            return Result<TimesheetDto>.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        var startDate = request.StartDateUtc.Date;
        var endDate = request.EndDateUtc.Date;

        var entries = await _context.TimeEntries
            .AsNoTracking()
            .Where(e => e.EmployeeId == request.EmployeeId && e.WorkDate >= startDate && e.WorkDate <= endDate)
            .ToListAsync(cancellationToken);

        var groupedByDate = entries
            .GroupBy(e => _dateTimeService.ToSwissTime(e.ClockInUtc).Date)
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
                    var breakMin = entry.BreakDurationMinutes ?? 0;
                    var net = gross - (breakMin / 60.0);
                    dayGross += gross;
                    dayBreak += breakMin;
                    dayNet += Math.Max(0, net);

                    dayNight += _policy.CalculateNightHours(entry.ClockInUtc, entry.ClockOutUtc.Value);
                    daySunday += _policy.CalculateSundayHours(entry.ClockInUtc, entry.ClockOutUtc.Value);
                }

                entryDtos.Add(entry.ToDto(_dateTimeService));
            }

            var dailyContractual = employee.ContractualWeeklyHours / 5.0m;
            var dailyBreakdown = _policy.SplitWorkHours((decimal)dayNet, dailyContractual, employee.StatutoryWeeklyLimit);

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

        var periodBreakdown = _policy.SplitWorkHours(
            (decimal)totalNet,
            employee.ContractualWeeklyHours,
            employee.StatutoryWeeklyLimit);

        var dto = new TimesheetDto(
            employee.Id,
            $"{employee.FirstName} {employee.LastName}".Trim(),
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
