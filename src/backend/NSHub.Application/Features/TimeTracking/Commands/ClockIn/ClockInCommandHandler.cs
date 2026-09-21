// <copyright file="ClockInCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.Extensions.Localization;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Features.TimeTracking.Mapping;
using NSHub.Application.Resources;
using NSHub.Domain.Common;
using NSHub.Domain.Entities;
using NSHub.Domain.Enums;
using NSHub.Domain.Services;
using NSHub.Domain.ValueObjects;

namespace NSHub.Application.Features.TimeTracking.Commands.ClockIn;

/// <summary>
/// MediatR request handler for processing employee clock-in punches.
/// </summary>
public class ClockInCommandHandler(
    ITimeEntryRepository timeEntryRepository,
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider,
    IStringLocalizer<ValidationMessages> localizer) : IRequestHandler<ClockInCommand, Result<TimeEntryDto>>
{
    private readonly SwissWorktimePolicy policy = new SwissWorktimePolicy();

    public async Task<Result<TimeEntryDto>> Handle(ClockInCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
        if (employee == null)
        {
            return Result<TimeEntryDto>.Failure(Error.NotFound("Employee.NotFound", localizer["EmployeeNotFound"]));
        }

        var activeEntry = await timeEntryRepository.GetActiveEntryForEmployeeAsync(request.EmployeeId, cancellationToken);
        if (activeEntry != null)
        {
            return Result<TimeEntryDto>.Failure(Error.Conflict("TimeEntry.ActiveExists", localizer["ActiveShiftAlreadyExists"]));
        }

        var nowUtc = dateTimeProvider.UtcNow;

        GpsCoordinate? gps = null;
        if (request.Latitude.HasValue && request.Longitude.HasValue)
        {
            gps = new GpsCoordinate(request.Latitude.Value, request.Longitude.Value, request.AccuracyMeters, nowUtc);
        }

        var entry = new TimeEntry(Guid.NewGuid(), employee.Id, nowUtc, gps, request.Notes);

        // Swiss legal check: 11 consecutive hours daily rest period (Art. 15a LL / Art. 19 OLL 1)
        var prevEntry = await timeEntryRepository.GetPreviousEntryBeforeAsync(request.EmployeeId, nowUtc, cancellationToken);
        if (prevEntry?.ClockOutUtc != null)
        {
            var (restHours, restViolated) = policy.EvaluateDailyRestPeriod(prevEntry.ClockOutUtc.Value, nowUtc);
            var violations = restViolated ? ViolationType.DAILY_REST_PERIOD_VIOLATED : ViolationType.NONE;
            entry.SetComplianceMetrics(restHours, restViolated, null, false, violations);
        }

        await timeEntryRepository.AddAsync(entry, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<TimeEntryDto>.Success(entry.ToDto(dateTimeProvider));
    }
}
