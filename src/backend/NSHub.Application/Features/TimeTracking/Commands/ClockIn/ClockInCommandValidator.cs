// <copyright file="ClockInCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using Microsoft.Extensions.Localization;
using NSHub.Application.Resources;

namespace NSHub.Application.Features.TimeTracking.Commands.ClockIn;

/// <summary>
/// FluentValidation validator for ClockInCommand.
/// </summary>
public class ClockInCommandValidator : AbstractValidator<ClockInCommand>
{
    public ClockInCommandValidator(IStringLocalizer<ValidationMessages> localizer)
    {
        _ = RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage(localizer["EmployeeIdRequired"]);
    }
}
