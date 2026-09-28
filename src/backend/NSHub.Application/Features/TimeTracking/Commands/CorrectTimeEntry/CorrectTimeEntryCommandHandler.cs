// <copyright file="CorrectTimeEntryCommandHandler.cs" company="Davide Nava">
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

namespace NSHub.Application.Features.TimeTracking.Commands.CorrectTimeEntry;

/// <summary>
/// MediatR request handler for applying retroactive manual corrections to time entries.
/// </summary>
public class CorrectTimeEntryCommandHandler(
    ITimeEntryRepository timeEntryRepository,
    IUnitOfWork unitOfWork,
    IDateTimeService dateTimeService) : IRequestHandler<CorrectTimeEntryCommand, Result<TimeEntryDto>>
{
    /// <inheritdoc/>
    public async Task<Result<TimeEntryDto>> Handle(CorrectTimeEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await timeEntryRepository.GetByIdAsync(request.TimeEntryId, cancellationToken);

        if (entry == null)
        {
            return Result<TimeEntryDto>.Failure([$"Time entry with ID '{request.TimeEntryId}' was not found."]);
        }

        entry.WorkDate = request.NewClockInUtc.Date;
        entry.StartTime = request.NewClockInUtc.TimeOfDay;
        entry.EndTime = request.NewClockOutUtc?.TimeOfDay;
        entry.BreakDurationMinutes = request.NewBreakMinutes;
        entry.Status = TimeEntryStatus.Corrected;
        entry.DateUpdate = dateTimeService.UtcNow;

        if (request.NewClockOutUtc.HasValue)
        {
            var totalMinutes = (request.NewClockOutUtc.Value - request.NewClockInUtc).TotalMinutes - request.NewBreakMinutes;
            entry.TotalHoursWorked = (decimal)Math.Max(0, Math.Round(totalMinutes / 60.0, 2));
        }

        await timeEntryRepository.UpdateAsync(entry, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<TimeEntryDto>.Success(entry.ToDto(dateTimeService));
    }
}
