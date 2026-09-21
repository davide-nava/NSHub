// <copyright file="GetEmployeeByIdQueryHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.Extensions.Localization;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.Employees.DTOs;
using NSHub.Application.Resources;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.Employees.Queries.GetEmployeeById;

/// <summary>
/// MediatR request handler for retrieving an employee by Id.
/// </summary>
public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository, IStringLocalizer<ValidationMessages> localizer) : IRequestHandler<GetEmployeeByIdQuery, Result<EmployeeDto>>
{
    public async Task<Result<EmployeeDto>> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.Id, cancellationToken);
        if (employee == null)
        {
            return Result<EmployeeDto>.Failure(Error.NotFound("Employee.NotFound", localizer["EmployeeNotFound"]));
        }

        return Result<EmployeeDto>.Success(EmployeeDto.FromEntity(employee));
    }
}
