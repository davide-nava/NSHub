// <copyright file="GetCurrentStatusQuery.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using MediatR;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.TimeTracking.DTOs;

namespace NSHub.Application.Features.TimeTracking.Queries.GetCurrentStatus;

/// <summary>
/// Query to obtain the live, real-time clock-in attendance status of an employee.
/// </summary>
/// <param name="EmployeeId">The unique identifier of the employee.</param>
public record GetCurrentStatusQuery(Guid EmployeeId) : IRequest<Result<CurrentTimeStatusDto>>;
