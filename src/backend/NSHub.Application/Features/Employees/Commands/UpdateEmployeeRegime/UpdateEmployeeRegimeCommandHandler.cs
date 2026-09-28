// <copyright file="UpdateEmployeeRegimeCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.Repositories;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeRegime;

/// <summary>
/// MediatR request handler for updating an employee's Swiss OLL 1 regime.
/// </summary>
public class UpdateEmployeeRegimeCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateEmployeeRegimeCommand, Result>
{
    /// <inheritdoc/>
    public async Task<Result> Handle(UpdateEmployeeRegimeCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);

        if (employee is null)
        {
            return Result.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        employee.Oll1Regime = request.Regime;

        await employeeRepository.UpdateAsync(employee, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
