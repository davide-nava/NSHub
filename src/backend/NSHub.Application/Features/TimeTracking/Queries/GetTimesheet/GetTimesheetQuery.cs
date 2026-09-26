// <copyright file="GetTimesheetQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using MediatR;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.TimeTracking.DTOs;

namespace NSHub.Application.Features.TimeTracking.Queries.GetTimesheet;

/// <summary>
/// Query to compute and retrieve an aggregated timesheet for an employee within a date interval.
/// </summary>
/// <param name="EmployeeId">The unique identifier of the employee.</param>
/// <param name="StartDateUtc">The inclusive start timestamp of the calculation period in UTC.</param>
/// <param name="EndDateUtc">The inclusive end timestamp of the calculation period in UTC.</param>
public record GetTimesheetQuery(
    Guid EmployeeId,
    DateTime StartDateUtc,
    DateTime EndDateUtc
) : IRequest<Result<TimesheetDto>>;
