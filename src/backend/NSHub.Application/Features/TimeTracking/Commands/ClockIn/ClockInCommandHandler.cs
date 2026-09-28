// <copyright file="ClockInCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.Repositories;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Application.Features.TimeTracking.Mapping;
using NSHub.Application.Features.TimeTracking.Repositories;
using NSHub.Domain.Entities;
using NSHub.Domain.Enums;

namespace NSHub.Application.Features.TimeTracking.Commands.ClockIn;

/// <summary>
/// MediatR request handler for processing employee clock-in punches.
/// </summary>
public class ClockInCommandHandler(
    IEmployeeRepository employeeRepository,
    ITimeEntryRepository timeEntryRepository,
    IUnitOfWork unitOfWork,
    IDateTimeService dateTimeService) : IRequestHandler<ClockInCommand, Result<TimeEntryDto>>
{
    /// <inheritdoc/>
    public async Task<Result<TimeEntryDto>> Handle(ClockInCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);

        if (employee is null)
        {
            return Result<TimeEntryDto>.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        var activeEntry = await timeEntryRepository.GetActiveEntryAsync(request.EmployeeId, cancellationToken);

        if (activeEntry != null)
        {
            return Result<TimeEntryDto>.Failure(["An active shift already exists for this employee."]);
        }

        var nowUtc = dateTimeService.UtcNow;
        var entry = new TimeEntry
        {
            Id = Guid.NewGuid(),
            EmployeeId = request.EmployeeId,
            WorkDate = nowUtc.Date,
            StartTime = nowUtc.TimeOfDay,
            Notes = request.Notes,
            Status = TimeEntryStatus.Open,
            DateInsert = nowUtc,
            DateUpdate = nowUtc,
        };

        _ = await timeEntryRepository.AddAsync(entry, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<TimeEntryDto>.Success(entry.ToDto(dateTimeService));
    }
}
