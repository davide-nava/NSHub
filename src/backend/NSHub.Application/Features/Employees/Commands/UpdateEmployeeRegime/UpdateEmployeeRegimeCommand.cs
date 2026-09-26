// <copyright file="UpdateEmployeeRegimeCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using MediatR;
using NSHub.Application.Common.Models;
using NSHub.Domain.Enums;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeRegime;

/// <summary>
/// Command to update the Swiss OLL 1 working time recording regime for an employee.
/// </summary>
/// <param name="EmployeeId">The unique identifier of the employee.</param>
/// <param name="Regime">The new Swiss OLL 1 working time regime.</param>
public record UpdateEmployeeRegimeCommand(Guid EmployeeId, Oll1Regime Regime) : IRequest<Result>;
