// <copyright file="GetCurrentStatusQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.Extensions.Localization;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Resources;
using NSHub.Domain.Common;
using NSHub.Domain.Services;

namespace NSHub.Application.Features.TimeTracking.Queries.GetCurrentStatus;

/// <summary>
/// MediatR request handler for retrieving the live attendance status of an employee.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetCurrentStatusQueryHandler"/> class.
/// </remarks>
/// <param name="employeeRepository">The employee repository.</param>
/// <param name="timeEntryRepository">The time entry repository.</param>
/// <param name="dateTimeProvider">The date and time provider.</param>
/// <param name="localizer">The string localizer.</param>
public class GetCurrentStatusQueryHandler(
    IEmployeeRepository employeeRepository,
    ITimeEntryRepository timeEntryRepository,
    IDateTimeProvider dateTimeProvider,
    IStringLocalizer<ValidationMessages> localizer) : IRequestHandler<GetCurrentStatusQuery, Result<CurrentTimeStatusDto>>
{
    private readonly SwissWorktimePolicy policy = new SwissWorktimePolicy();

    /// <inheritdoc/>
    public async Task<Result<CurrentTimeStatusDto>> Handle(GetCurrentStatusQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
        if (employee == null)
        {
            return Result<CurrentTimeStatusDto>.Failure(Error.NotFound("Employee.NotFound", localizer["EmployeeNotFound"]));
        }

        var activeEntry = await timeEntryRepository.GetActiveEntryForEmployeeAsync(request.EmployeeId, cancellationToken);

        var isClockedIn = activeEntry != null;
        DateTime? clockInUtc = activeEntry?.ClockInUtc;
        DateTime? clockInSwiss = clockInUtc.HasValue ? dateTimeProvider.ToSwissTime(clockInUtc.Value) : null;

        double elapsedWorkedHours = 0;
        int suggestedBreakMinutes = 0;

        if (isClockedIn && clockInUtc.HasValue)
        {
            elapsedWorkedHours = Math.Round((dateTimeProvider.UtcNow - clockInUtc.Value).TotalHours, 2);
            suggestedBreakMinutes = policy.CalculateStatutoryBreakMinutes(elapsedWorkedHours);
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
            $"{employee.FirstName} {employee.LastName}"
        );

        return Result<CurrentTimeStatusDto>.Success(dto);
    }
}
