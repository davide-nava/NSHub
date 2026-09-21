// <copyright file="UpdateEmployeeContractCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeContract;

using FluentValidation;

/// <summary>
/// Validator for <see cref="UpdateEmployeeContractCommand"/>.
/// </summary>
public sealed class UpdateEmployeeContractCommandValidator : AbstractValidator<UpdateEmployeeContractCommand>
{
    public UpdateEmployeeContractCommandValidator()
    {
        _ = RuleFor(x => x.EmployeeId)
            .NotEmpty().WithMessage("Employee ID is required.");

        _ = RuleFor(x => x.WeeklyHours)
            .InclusiveBetween(1, 60).WithMessage("Contractual weekly hours must be between 1 and 60.");
    }
}
