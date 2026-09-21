// <copyright file="UpdateEmployeeLanguageCommandHandler.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using MediatR;
using Microsoft.Extensions.Localization;
using NSHub.Application.Common.Interfaces;
using NSHub.Application.Resources;
using NSHub.Domain.Common;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeLanguage;

/// <summary>
/// MediatR request handler for updating an employee's preferred language.
/// </summary>
public class UpdateEmployeeLanguageCommandHandler(
    IEmployeeRepository employeeRepository,
    IUnitOfWork unitOfWork,
    IStringLocalizer<ValidationMessages> localizer) : IRequestHandler<UpdateEmployeeLanguageCommand, Result>
{
    public async Task<Result> Handle(UpdateEmployeeLanguageCommand request, CancellationToken cancellationToken)
    {
        var employee = await employeeRepository.GetByIdAsync(request.EmployeeId, cancellationToken);
        if (employee == null)
        {
            return Result.Failure(Error.NotFound("Employee.NotFound", localizer["EmployeeNotFound"]));
        }

        employee.SetPreferredLanguage(request.Language);
        employeeRepository.Update(employee);
        _ = await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success();
    }
}
