// <copyright file="UpdateEmployeeContractCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.DTOs;
using NSHub.Application.Features.Employees.Repositories;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeContract;

/// <summary>
/// Handler for <see cref="UpdateEmployeeContractCommand"/>.
/// </summary>
public sealed class UpdateEmployeeContractCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateEmployeeContractCommand, Result<EmployeeDto>>
{
    /// <inheritdoc/>
    public async Task<Result<EmployeeDto>> Handle(UpdateEmployeeContractCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);

        if (employee is null)
        {
            return Result<EmployeeDto>.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        employee.ContractualWeeklyHours = request.WeeklyHours;
        employee.StatutoryWeeklyLimit = request.Limit;

        await employeeRepository.UpdateAsync(employee, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<EmployeeDto>.Success(EmployeeDto.FromEntity(employee));
    }
}
