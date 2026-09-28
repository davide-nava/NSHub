// <copyright file="GetCurrentStatusQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.Repositories;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Features.TimeTracking.Repositories;
using NSHub.Application.Services;

namespace NSHub.Application.Features.TimeTracking.Queries.GetCurrentStatus;

/// <summary>
/// MediatR request handler for retrieving the live attendance status of an employee.
/// </summary>
public class GetCurrentStatusQueryHandler(
    IEmployeeRepository employeeRepository,
    ITimeEntryRepository timeEntryRepository,
    IDateTimeService dateTimeService) : IRequestHandler<GetCurrentStatusQuery, Result<CurrentTimeStatusDto>>
{
    /// <inheritdoc/>
    public async Task<Result<CurrentTimeStatusDto>> Handle(GetCurrentStatusQuery request, CancellationToken cancellationToken)
    {
        ArgumentNullException.ThrowIfNull(request);
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);

        if (employee == null)
        {
            return Result<CurrentTimeStatusDto>.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        var activeEntry = await timeEntryRepository.GetActiveEntryAsync(request.EmployeeId, cancellationToken);

        var isClockedIn = activeEntry != null;
        DateTime? clockInUtc = activeEntry?.ClockInUtc;
        DateTime? clockInSwiss = clockInUtc.HasValue ? dateTimeService.ToSwissTime(clockInUtc.Value) : null;

        double elapsedWorkedHours = 0;
        int suggestedBreakMinutes = 0;

        if (isClockedIn && clockInUtc.HasValue)
        {
            elapsedWorkedHours = Math.Round((dateTimeService.UtcNow - clockInUtc.Value).TotalHours, 2);
            suggestedBreakMinutes = SwissWorktimePolicy.CalculateStatutoryBreakMinutes(elapsedWorkedHours);
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
