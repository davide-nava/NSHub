// <copyright file="ClockInCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.TimeTracking.Commands.ClockIn;

/// <summary>
/// Command to register an employee's clock-in punch with optional punctual GPS coordinates.
/// </summary>
public record ClockInCommand(
    Guid EmployeeId,
    double? Latitude = null,
    double? Longitude = null,
    double? AccuracyMeters = null,
    string? Notes = null
) : IRequest<Result<TimeEntryDto>>;
