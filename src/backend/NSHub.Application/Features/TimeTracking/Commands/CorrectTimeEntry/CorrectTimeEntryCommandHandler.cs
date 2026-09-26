// <copyright file="CorrectTimeEntryCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.EntityFrameworkCore;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Features.TimeTracking.Mapping;
using NSHub.Domain.Enums;

namespace NSHub.Application.Features.TimeTracking.Commands.CorrectTimeEntry;

/// <summary>
/// MediatR request handler for applying retroactive manual corrections to time entries.
/// </summary>
public class CorrectTimeEntryCommandHandler : IRequestHandler<CorrectTimeEntryCommand, Result<TimeEntryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public CorrectTimeEntryCommandHandler(IApplicationDbContext context, IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc/>
    public async Task<Result<TimeEntryDto>> Handle(CorrectTimeEntryCommand request, CancellationToken cancellationToken)
    {
        var entry = await _context.TimeEntries
            .FirstOrDefaultAsync(t => t.Id == request.TimeEntryId, cancellationToken);

        if (entry == null)
        {
            return Result<TimeEntryDto>.Failure([$"Time entry with ID '{request.TimeEntryId}' was not found."]);
        }

        entry.WorkDate = request.NewClockInUtc.Date;
        entry.StartTime = request.NewClockInUtc.TimeOfDay;
        entry.EndTime = request.NewClockOutUtc?.TimeOfDay;
        entry.BreakDurationMinutes = request.NewBreakMinutes;
        entry.Status = TimeEntryStatus.Corrected;

        if (request.NewClockOutUtc.HasValue)
        {
            var totalMinutes = (request.NewClockOutUtc.Value - request.NewClockInUtc).TotalMinutes - request.NewBreakMinutes;
            entry.TotalHoursWorked = (decimal)System.Math.Max(0, totalMinutes / 60.0);
        }

        await _context.SaveChangesAsync(cancellationToken);

        return Result<TimeEntryDto>.Success(entry.ToDto(_dateTimeService));
    }
}
