// <copyright file="UpdateEmployeeRegimeCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Domain.Common;
using NSHub.Domain.Enums;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeRegime;

/// <summary>
/// Command to update the Swiss OLL 1 working time recording regime for an employee.
/// </summary>
public record UpdateEmployeeRegimeCommand(Guid EmployeeId, Oll1Regime Regime) : IRequest<Result>;
