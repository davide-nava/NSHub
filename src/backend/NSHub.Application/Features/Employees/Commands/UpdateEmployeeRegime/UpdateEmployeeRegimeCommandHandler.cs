// <copyright file="UpdateEmployeeRegimeCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.Extensions.Localization;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Resources;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeRegime;

/// <summary>
/// MediatR request handler for updating an employee's OLL 1 working time regime.
/// </summary>
public class UpdateEmployeeRegimeCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork,
    IStringLocalizer<ValidationMessages> localizer) : IRequestHandler<UpdateEmployeeRegimeCommand, Result>
{
    public async Task<Result> Handle(UpdateEmployeeRegimeCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
        if (employee == null)
        {
            return Result.Failure(Error.NotFound("Employee.NotFound", localizer["EmployeeNotFound"]));
        }

        employee.UpdateOll1Regime(request.Regime);
        employeeRepository.Update(employee);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
