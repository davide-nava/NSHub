// <copyright file="UpdateEmployeeContractCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeContract;

using MediatR;
using NSHub.Application.Features.Employees.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Enums;

/// <summary>
/// Command to update contractual working hours and statutory limits for an employee.
/// </summary>
public sealed record UpdateEmployeeContractCommand(
    Guid EmployeeId,
    decimal WeeklyHours,
    StatutoryWeeklyLimit Limit) : IRequest<Result<EmployeeDto>>;
