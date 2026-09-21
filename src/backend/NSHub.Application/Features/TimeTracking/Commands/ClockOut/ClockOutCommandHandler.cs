// <copyright file="ClockOutCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.Extensions.Localization;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Features.TimeTracking.Mapping;
using NSHub.Application.Resources;
using NSHub.Domain.Common;
using NSHub.Domain.Enums;
using NSHub.Domain.Services;
using NSHub.Domain.ValueObjects;

namespace NSHub.Application.Features.TimeTracking.Commands.ClockOut;

/// <summary>
/// MediatR request handler for processing employee clock-out punches.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="ClockOutCommandHandler"/> class.
/// </remarks>
/// <param name="timeEntryRepository">The time entry repository.</param>
/// <param name="unitOfWork">The unit of work.</param>
/// <param name="dateTimeProvider">The date and time provider.</param>
/// <param name="localizer">The string localizer.</param>
public class ClockOutCommandHandler(
    ITimeEntryRepository timeEntryRepository,
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider,
    IStringLocalizer<ValidationMessages> localizer) : IRequestHandler<ClockOutCommand, Result<TimeEntryDto>>
{
    private readonly SwissWorktimePolicy policy = new SwissWorktimePolicy();

    /// <inheritdoc/>
    public async Task<Result<TimeEntryDto>> Handle(ClockOutCommand request, CancellationToken cancellationToken)
    {
        var activeEntry = await timeEntryRepository.GetActiveEntryForEmployeeAsync(request.EmployeeId, cancellationToken);
        if (activeEntry == null)
        {
            return Result<TimeEntryDto>.Failure(Error.NotFound("TimeEntry.NotFound", localizer["NoActiveShiftFound"]));
        }

        var nowUtc = dateTimeProvider.UtcNow;

        GpsCoordinate? gps = null;
        if (request.Latitude.HasValue && request.Longitude.HasValue)
        {
            gps = new GpsCoordinate(request.Latitude.Value, request.Longitude.Value, request.AccuracyMeters, nowUtc);
        }

        var clockOutResult = activeEntry.ClockOut(nowUtc, request.BreakDurationMinutes, gps);
        if (clockOutResult.IsFailure)
        {
            return Result<TimeEntryDto>.Failure(clockOutResult.Error);
        }

        // Evaluate daily maximum amplitude (Art. 10 LL / Art. 13 OLL 1: max 14h)
        var (amplitudeHours, amplitudeExceeded) = policy.EvaluateDailyAmplitude(activeEntry.ClockInUtc, nowUtc);

        // Evaluate statutory mandatory breaks (Art. 15 LL)
        var workedHours = (nowUtc - activeEntry.ClockInUtc).TotalHours;
        var requiredBreakMinutes = policy.CalculateStatutoryBreakMinutes(workedHours);
        var breakInsufficient = request.BreakDurationMinutes < requiredBreakMinutes;

        var violations = activeEntry.Violations;
        if (amplitudeExceeded)
        {
            violations |= ViolationType.DailyAmplitudeExceeded;
        }

        if (breakInsufficient)
        {
            violations |= ViolationType.InsufficientBreak;
        }

        activeEntry.SetComplianceMetrics(
            activeEntry.RestPeriodHoursBeforeShift,
            activeEntry.DailyRestPeriodViolated,
            amplitudeHours,
            amplitudeExceeded,
            violations);

        timeEntryRepository.Update(activeEntry);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<TimeEntryDto>.Success(activeEntry.ToDto(dateTimeProvider));
    }
}
