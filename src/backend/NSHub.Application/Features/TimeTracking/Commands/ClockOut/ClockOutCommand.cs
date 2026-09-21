// <copyright file="ClockOutCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.TimeTracking.Commands.ClockOut;

/// <summary>
/// Command to register an employee's clock-out punch with break duration and optional punctual GPS coordinates.
/// </summary>
public record ClockOutCommand(
    Guid EmployeeId,
    int BreakDurationMinutes = 0,
    double? Latitude = null,
    double? Longitude = null,
    double? AccuracyMeters = null
) : IRequest<Result<TimeEntryDto>>;
