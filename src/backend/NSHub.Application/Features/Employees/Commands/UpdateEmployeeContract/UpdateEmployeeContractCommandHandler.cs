// <copyright file="UpdateEmployeeContractCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeContract;

using MediatR;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Features.Employees.DTOs;
using NSHub.Domain.Common;

/// <summary>
/// Handler for <see cref="UpdateEmployeeContractCommand"/>.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="UpdateEmployeeContractCommandHandler"/> class.
/// </remarks>
/// <param name="employeeRepository">The employee repository.</param>
/// <param name="unitOfWork">The unit of work.</param>
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
            return Result<EmployeeDto>.Failure(Error.NotFound("Employee.NotFound", $"Employee with ID '{request.EmployeeId}' was not found."));
        }

        employee.UpdateContractualTerms(request.WeeklyHours, request.Limit);
        employeeRepository.Update(employee);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result<EmployeeDto>.Success(EmployeeDto.FromEntity(employee));
    }
}
