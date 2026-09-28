// <copyright file="UpdateEmployeeLanguageCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using Microsoft.Extensions.Localization;
using NSHub.Application.Resources;

namespace NSHub.Application.Features.Employees.Commands.UpdateEmployeeLanguage;

/// <summary>
/// FluentValidation validator for UpdateEmployeeLanguageCommand.
/// </summary>
public class UpdateEmployeeLanguageCommandValidator : AbstractValidator<UpdateEmployeeLanguageCommand>
{
    public UpdateEmployeeLanguageCommandValidator(IStringLocalizer<ValidationMessages> localizer)
    {
        _ = RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage(localizer["EmployeeIdRequired"]);

        _ = RuleFor(x => x.Language)
            .IsInEnum()
            .WithMessage(localizer["GeneralError"]);
    }
}
