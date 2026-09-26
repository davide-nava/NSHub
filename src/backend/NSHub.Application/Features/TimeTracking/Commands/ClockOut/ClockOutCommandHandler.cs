// <copyright file="ClockOutCommandHandler.cs" company="Davide Nava">
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

namespace NSHub.Application.Features.TimeTracking.Commands.ClockOut;

/// <summary>
/// MediatR request handler for processing employee clock-out punches.
/// </summary>
public class ClockOutCommandHandler : IRequestHandler<ClockOutCommand, Result<TimeEntryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public ClockOutCommandHandler(IApplicationDbContext context, IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc/>
    public async Task<Result<TimeEntryDto>> Handle(ClockOutCommand request, CancellationToken cancellationToken)
    {
        var activeEntry = await _context.TimeEntries
            .FirstOrDefaultAsync(t => t.EmployeeId == request.EmployeeId && t.EndTime == null, cancellationToken);

        if (activeEntry == null)
        {
            return Result<TimeEntryDto>.Failure(["No active shift found for this employee."]);
        }

        var nowUtc = _dateTimeService.UtcNow;
        activeEntry.ClockOut(nowUtc, request.BreakDurationMinutes);

        await _context.SaveChangesAsync(cancellationToken);

        return Result<TimeEntryDto>.Success(activeEntry.ToDto(_dateTimeService));
    }
}
