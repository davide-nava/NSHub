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
/// <param name="FirstName">The employee first name.</param>
/// <param name="LastName">The employee last name.</param>
/// <param name="Email">The unique employee email address.</param>
/// <param name="Department">The assigned department or organizational unit.</param>
/// <param name="ContractualWeeklyHours">The weekly working hours agreed in the employment contract.</param>
/// <param name="StatutoryWeeklyLimit">The Swiss statutory maximum weekly hours limit.</param>
/// <param name="Oll1Regime">The Swiss OLL 1 working time recording regime.</param>
/// <param name="PreferredLanguage">The preferred language for communications and reports.</param>
public sealed record CreateEmployeeCommand(
    string FirstName,
    string LastName,
    string Email,
    string Department,
    decimal ContractualWeeklyHours,
    StatutoryWeeklyLimit StatutoryWeeklyLimit,
    Oll1Regime Oll1Regime,
    LanguageCode PreferredLanguage) : IRequest<Result<EmployeeDto>>;
