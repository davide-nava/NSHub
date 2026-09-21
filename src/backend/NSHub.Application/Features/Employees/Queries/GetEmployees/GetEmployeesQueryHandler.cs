// <copyright file="GetEmployeesQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.Employees.DTOs;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.Employees.Queries.GetEmployees;

/// <summary>
/// MediatR request handler for retrieving all employees.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="GetEmployeesQueryHandler"/> class.
/// </remarks>
/// <param name="employeeRepository">The employee repository.</param>
public class GetEmployeesQueryHandler(IEmployeeRepository employeeRepository) : IRequestHandler<GetEmployeesQuery, Result<List<EmployeeDto>>>
{
    /// <inheritdoc/>
    public async Task<Result<List<EmployeeDto>>> Handle(GetEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await employeeRepository.GetAllAsync(cancellationToken);
        var dtos = employees.Select(EmployeeDto.FromEntity).ToList();
        return Result<List<EmployeeDto>>.Success(dtos);
    }
}
