// <copyright file="ClockOutCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using Microsoft.Extensions.Localization;
using NSHub.Application.Resources;

namespace NSHub.Application.Features.TimeTracking.Commands.ClockOut;

/// <summary>
/// FluentValidation validator for ClockOutCommand.
/// </summary>
public class ClockOutCommandValidator : AbstractValidator<ClockOutCommand>
{
    public ClockOutCommandValidator(IStringLocalizer<ValidationMessages> localizer)
    {
        _ = RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage(localizer["EmployeeIdRequired"]);

        _ = RuleFor(x => x.BreakDurationMinutes)
            .GreaterThanOrEqualTo(0)
            .WithMessage(localizer["BreakDurationNegative"]);
    }
}
