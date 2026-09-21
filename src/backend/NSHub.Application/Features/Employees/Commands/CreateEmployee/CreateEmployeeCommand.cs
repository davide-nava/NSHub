// <copyright file="CreateEmployeeCommand.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Features.Employees.Commands.CreateEmployee;

using MediatR;
using NSHub.Application.Features.Employees.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Enums;

/// <summary>
/// Command to create a new employee profile.
/// </summary>
public sealed record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string Email,
    string Department,
    decimal ContractualWeeklyHours,
    StatutoryWeeklyLimit StatutoryWeeklyLimit,
    Oll1Regime Oll1Regime,
    LanguageCode PreferredLanguage) : IRequest<Result<EmployeeDto>>;
