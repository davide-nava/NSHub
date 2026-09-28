// <copyright file="CreateEmployeeCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.DTOs;
using NSHub.Application.Features.Employees.Repositories;
using NSHub.Domain.Entities;

namespace NSHub.Application.Features.Employees.Commands.CreateEmployee;

/// <summary>
/// Handler for <see cref="CreateEmployeeCommand"/>.
/// </summary>
public sealed class CreateEmployeeCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<CreateEmployeeCommand, Result<EmployeeDto>>
{
    /// <inheritdoc/>
    public async Task<Result<EmployeeDto>> Handle(CreateEmployeeCommand request, CancellationToken cancellationToken)
    {
        var emailExists = await employeeRepository.EmailExistsAsync(request.Email, cancellationToken);

        if (emailExists)
        {
            return Result<EmployeeDto>.Failure(["An employee with the specified email already exists."]);
        }

        var employee = new Employee
        {
            Id = Guid.NewGuid(),
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email,
            Department = request.Department,
            ContractualWeeklyHours = request.ContractualWeeklyHours,
            StatutoryWeeklyLimit = request.StatutoryWeeklyLimit,
            Oll1Regime = request.Oll1Regime,
            PreferredLanguage = request.PreferredLanguage,
            IsActive = true,
        };

        _ = await employeeRepository.AddAsync(employee, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<EmployeeDto>.Success(EmployeeDto.FromEntity(employee));
    }
}
