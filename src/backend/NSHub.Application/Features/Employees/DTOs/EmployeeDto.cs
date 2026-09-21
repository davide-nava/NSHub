// <copyright file="EmployeeDto.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Entities;
using NSHub.Domain.Enums;

namespace NSHub.Application.Features.Employees.DTOs;

/// <summary>
/// Data transfer object representing an employee.
/// </summary>
/// <param name="Id">The unique identifier of the employee.</param>
/// <param name="FirstName">The employee first name.</param>
/// <param name="LastName">The employee last name.</param>
/// <param name="Email">The employee email address.</param>
/// <param name="Department">The assigned department or organizational unit.</param>
/// <param name="ContractualWeeklyHours">The contractual weekly hours.</param>
/// <param name="StatutoryWeeklyLimit">The statutory weekly hours limit.</param>
/// <param name="Oll1Regime">The Swiss OLL 1 working time recording regime.</param>
/// <param name="PreferredLanguage">The preferred communication language.</param>
/// <param name="IsActive">A value indicating whether the employee profile is active.</param>
public record EmployeeDto(
    Guid Id,
    string FirstName,
    string LastName,
    string Email,
    string Department,
    decimal ContractualWeeklyHours,
    StatutoryWeeklyLimit StatutoryWeeklyLimit,
    Oll1Regime Oll1Regime,
    LanguageCode PreferredLanguage,
    bool IsActive
)
{
    /// <summary>
    /// Creates an <see cref="EmployeeDto"/> from an <see cref="Employee"/> domain entity.
    /// </summary>
    /// <param name="employee">The employee domain entity.</param>
    /// <returns>A new <see cref="EmployeeDto"/> instance.</returns>
    public static EmployeeDto FromEntity(Employee employee) => new(
        employee.Id,
        employee.FirstName,
        employee.LastName,
        employee.Email,
        employee.Department,
        employee.ContractualWeeklyHours,
        employee.StatutoryWeeklyLimit,
        employee.Oll1Regime,
        employee.PreferredLanguage,
        employee.IsActive
    );
}
