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
/// <param name="EmployeeId">The unique identifier of the employee.</param>
/// <param name="BreakDurationMinutes">The total duration of breaks taken during the shift, in minutes.</param>
/// <param name="Latitude">The optional GPS latitude coordinate.</param>
/// <param name="Longitude">The optional GPS longitude coordinate.</param>
/// <param name="AccuracyMeters">The optional GPS accuracy in meters.</param>
public record ClockOutCommand(
    Guid EmployeeId,
    int BreakDurationMinutes = 0,
    double? Latitude = null,
    double? Longitude = null,
    double? AccuracyMeters = null
) : IRequest<Result<TimeEntryDto>>;
