// <copyright file="UpdateEmployeeLanguageCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using NSHub.Application.Common.Interfaces.Repositories;
using NSHub.Application.Common.Models;
using NSHub.Application.Features.Employees.Repositories;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeLanguage;

/// <summary>
/// MediatR request handler for updating an employee's preferred language.
/// </summary>
public class UpdateEmployeeLanguageCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork) : IRequestHandler<UpdateEmployeeLanguageCommand, Result>
{
    /// <inheritdoc/>
    public async Task<Result> Handle(UpdateEmployeeLanguageCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);

        if (employee is null)
        {
            return Result.Failure([$"Employee with ID '{request.EmployeeId}' was not found."]);
        }

        employee.PreferredLanguage = request.Language;

        await employeeRepository.UpdateAsync(employee, cancellationToken);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
