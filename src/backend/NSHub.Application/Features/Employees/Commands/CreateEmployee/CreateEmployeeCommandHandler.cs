// <copyright file="CreateEmployeeCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Features.Employees.Commands.CreateEmployee;

using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.Employees.DTOs;
using NSHub.Domain.Common;
using NSHub.Domain.Entities;
using NSHub.Domain.HR.ValueObjects;

/// <summary>
/// Handler for <see cref="CreateEmployeeCommand"/>.
/// </summary>
public sealed class CreateEmployeeCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateEmployeeCommand, Result<EmployeeDto>>
{
    public async Task<Result<EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var existing = await employeeRepository.GetByEmailAsync(request.Email, cancellationToken);
        if (existing is not null)
        {
            return Result<EmployeeDto>.Failure(Error.Conflict("Employee.EmailExists", "An employee with the specified email already exists."));
        }

        var employee = new Employee(
            EmployeeId.New(),
            request.FirstName,
            request.LastName,
            request.Email,
            request.Department,
            request.ContractualWeeklyHours,
            request.StatutoryWeeklyLimit,
            request.Oll1Regime,
            request.PreferredLanguage);

        await employeeRepository.AddAsync(employee, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<EmployeeDto>.Success(EmployeeDto.FromEntity(employee));
    }
}
