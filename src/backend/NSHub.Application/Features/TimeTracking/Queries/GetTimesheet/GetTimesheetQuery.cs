// <copyright file="GetTimesheetQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Features.TimeTracking.DTOs;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.TimeTracking.Queries.GetTimesheet;

/// <summary>
/// Query to compute and retrieve an aggregated timesheet for an employee within a date interval.
/// </summary>
public record GetTimesheetQuery(
    Guid EmployeeId,
    DateTime StartDateUtc,
    DateTime EndDateUtc
) : IRequest<Result<TimesheetDto>>;
