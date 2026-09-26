// <copyright file="ClockInCommandHandler.cs" company="Davide Nava">
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
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.TimeTracking.Commands.ClockIn;

/// <summary>
/// MediatR request handler for processing employee clock-in punches.
/// </summary>
public class ClockInCommandHandler : IRequestHandler<ClockInCommand, Result<TimeEntryDto>>
{
    private readonly IApplicationDbContext _context;
    private readonly IDateTimeService _dateTimeService;

    public ClockInCommandHandler(IApplicationDbContext context, IDateTimeService dateTimeService)
    {
        _context = context;
        _dateTimeService = dateTimeService;
    }

    /// <inheritdoc/>
    public async Task<Result<TimeEntryDto>> Handle(ClockInCommand request, CancellationToken cancellationToken)
    {
        var employee = await _context.Employees
            .FirstOrDefaultAsync(e => e.Id == request.EmployeeId, cancellationToken);

        if (employee is null)
        {
            return Result<TimeEntryDto>.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        var activeEntry = await _context.TimeEntries
            .FirstOrDefaultAsync(t => t.EmployeeId == request.EmployeeId && t.EndTime == null, cancellationToken);

        if (activeEntry != null)
        {
            return Result<TimeEntryDto>.Failure(["An active shift already exists for this employee."]);
        }

        var nowUtc = _dateTimeService.UtcNow;
        var entry = TimeEntry.Create(request.EmployeeId, nowUtc, request.Notes);

        _context.TimeEntries.Add(entry);
        await _context.SaveChangesAsync(cancellationToken);

        return Result<TimeEntryDto>.Success(entry.ToDto(_dateTimeService));
    }
}
