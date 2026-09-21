// <copyright file="CorrectTimeEntryCommandHandler.cs" company="Davide Nava">
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

namespace NSHub.Application.Features.TimeTracking.Commands.CorrectTimeEntry;

/// <summary>
/// MediatR request handler for processing retroactive time entry corrections and compliance recalculation.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="CorrectTimeEntryCommandHandler"/> class.
/// </remarks>
/// <param name="timeEntryRepository">The time entry repository.</param>
/// <param name="unitOfWork">The unit of work.</param>
/// <param name="dateTimeProvider">The date and time provider.</param>
/// <param name="currentUserService">The current user service.</param>
/// <param name="localizer">The string localizer.</param>
public class CorrectTimeEntryCommandHandler(
    ITimeEntryRepository timeEntryRepository,
    IUnitOfWork unitOfWork,
    IDateTimeProvider dateTimeProvider,
    ICurrentUserService currentUserService,
    IStringLocalizer<ValidationMessages> localizer) : IRequestHandler<CorrectTimeEntryCommand, Result<TimeEntryDto>>
{
    private readonly SwissWorktimePolicy policy = new SwissWorktimePolicy();

    /// <inheritdoc/>
    public async Task<Result<TimeEntryDto>> Handle(CorrectTimeEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await timeEntryRepository.GetByIdAsync(request.TimeEntryId, cancellationToken);
        if (entry == null)
        {
            return Result<TimeEntryDto>.Failure(Error.NotFound("TimeEntry.NotFound", localizer["TimeEntryNotFound"]));
        }

        // Apply domain correction and generate immutable audit log record
        var operatorId = request.OperatorId != Guid.Empty
            ? request.OperatorId
            : currentUserService.UserId ?? Guid.Empty;

        var correctionResult = entry.ApplyCorrection(
            operatorId,
            request.NewClockInUtc,
            request.NewClockOutUtc,
            request.NewBreakMinutes,
            request.MandatoryReason);

        if (correctionResult.IsFailure)
        {
            return Result<TimeEntryDto>.Failure(correctionResult.Error);
        }

        // Recalculate Swiss labor compliance violations
        if (request.NewClockOutUtc.HasValue)
        {
            var (ampHours, ampExceeded) = policy.EvaluateDailyAmplitude(request.NewClockInUtc, request.NewClockOutUtc.Value);
            var workedHours = (request.NewClockOutUtc.Value - request.NewClockInUtc).TotalHours;
            var requiredBreak = policy.CalculateStatutoryBreakMinutes(workedHours);
            var breakInsufficient = request.NewBreakMinutes < requiredBreak;

            var violations = ViolationType.None;
            if (entry.DailyRestPeriodViolated)
            {
                violations |= ViolationType.DailyRestPeriodViolated;
            }

            if (ampExceeded)
            {
                violations |= ViolationType.DailyAmplitudeExceeded;
            }

            if (breakInsufficient)
            {
                violations |= ViolationType.InsufficientBreak;
            }

            entry.SetComplianceMetrics(
                entry.RestPeriodHoursBeforeShift,
                entry.DailyRestPeriodViolated,
                ampHours,
                ampExceeded,
                violations);
        }

        await timeEntryRepository.AddCorrectionAuditAsync(correctionResult.Value, cancellationToken);
        timeEntryRepository.Update(entry);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<TimeEntryDto>.Success(entry.ToDto(dateTimeProvider));
    }
}
