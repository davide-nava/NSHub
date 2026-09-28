// <copyright file="UpdateEmployeeRegimeCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using Microsoft.Extensions.Localization;
using NSHub.Application.Resources;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeRegime;

/// <summary>
/// FluentValidation validator for UpdateEmployeeRegimeCommand.
/// </summary>
public class UpdateEmployeeRegimeCommandValidator : AbstractValidator<UpdateEmployeeRegimeCommand>
{
    public UpdateEmployeeRegimeCommandValidator(IStringLocalizer<ValidationMessages> localizer)
    {
        _ = RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage(localizer["EmployeeIdRequired"]);

        _ = RuleFor(x => x.Regime)
            .IsInEnum()
            .WithMessage(localizer["GeneralError"]);
    }
}
