// <copyright file="ClockOutCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Features.TimeTracking.Mapping;
using NSHub.Application.Features.TimeTracking.Repositories;
using NSHub.Domain.Enums;

namespace NSHub.Application.Features.TimeTracking.Commands.ClockOut;

/// <summary>
/// MediatR request handler for processing employee clock-out punches.
/// </summary>
public class ClockOutCommandHandler(
    ITimeEntryRepository timeEntryRepository,
    IUnitOfWork unitOfWork,
    IDateTimeService dateTimeService) : IRequestHandler<ClockOutCommand, Result<TimeEntryDto>>
{
    /// <inheritdoc/>
    public async Task<Result<TimeEntryDto>> Handle(ClockOutCommand request, CancellationToken cancellationToken)
    {
        var activeEntry = await timeEntryRepository.GetActiveEntryAsync(request.EmployeeId, cancellationToken);

        if (activeEntry == null)
        {
            return Result<TimeEntryDto>.Failure(["No active shift found for this employee."]);
        }

        var nowUtc = dateTimeService.UtcNow;
        activeEntry.EndTime = nowUtc.TimeOfDay;
        activeEntry.BreakDurationMinutes = request.BreakDurationMinutes;
        var totalMinutes = (nowUtc.TimeOfDay - (activeEntry.StartTime ?? nowUtc.TimeOfDay)).TotalMinutes - request.BreakDurationMinutes;
        activeEntry.TotalHoursWorked = (decimal)Math.Max(0, Math.Round(totalMinutes / 60.0, 2));
        activeEntry.Status = TimeEntryStatus.Closed;
        activeEntry.DateUpdate = nowUtc;

        await timeEntryRepository.UpdateAsync(activeEntry, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<TimeEntryDto>.Success(activeEntry.ToDto(dateTimeService));
    }
}
