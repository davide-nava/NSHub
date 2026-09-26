// <copyright file="GetCurrentStatusQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Domain.Services;

namespace NSHub.Application.Features.TimeTracking.Queries.GetCurrentStatus;

/// <summary>
/// MediatR request handler for retrieving the live attendance status of an employee.
/// </summary>
public class GetCurrentStatusQueryHandler : IRequestHandler<GetCurrentStatusQuery, Result<CurrentTimeStatusDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;
    private readonly SwissWorktimePolicy _policy = new();

    public GetCurrentStatusQueryHandler(IApplicationDbContext context, IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc/>
    public async Task<Result<CurrentTimeStatusDto>> Handle(GetCurrentStatusQuery request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .AsNoTracking()
            .FirstOrDefaultAsync(e => e.Id == request.EmployeeId, cancellationToken);

        if (employee == null)
        {
            return Result<CurrentTimeStatusDto>.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        var activeEntry = await _context.TimeEntries
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.EmployeeId == request.EmployeeId && t.EndTime == null, cancellationToken);

        var isClockedIn = activeEntry != null;
        DateTime? clockInUtc = activeEntry?.ClockInUtc;
        DateTime? clockInSwiss = clockInUtc.HasValue ? _dateTimeService.ToSwissTime(clockInUtc.Value) : null;

        double elapsedWorkedHours = 0;
        int suggestedBreakMinutes = 0;

        if (isClockedIn && clockInUtc.HasValue)
        {
            elapsedWorkedHours = Math.Round((_dateTimeService.UtcNow - clockInUtc.Value).TotalHours, 2);
            suggestedBreakMinutes = _policy.CalculateStatutoryBreakMinutes(elapsedWorkedHours);
        }

        var dto = new CurrentTimeStatusDto(
            employee.Id,
            isClockedIn,
            activeEntry?.Id,
            clockInUtc,
            clockInSwiss,
            elapsedWorkedHours,
            suggestedBreakMinutes,
            employee.Oll1Regime,
            $"{employee.FirstName} {employee.LastName}".Trim()
        );

        return Result<CurrentTimeStatusDto>.Success(dto);
    }
}
