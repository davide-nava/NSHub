// <copyright file="CorrectTimeEntryCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using Microsoft.Extensions.Localization;
using NSHub.Application.Resources;

namespace NSHub.Application.Features.TimeTracking.Commands.CorrectTimeEntry;

/// <summary>
/// FluentValidation validator for CorrectTimeEntryCommand.
/// </summary>
public class CorrectTimeEntryCommandValidator : AbstractValidator<CorrectTimeEntryCommand>
{
    public CorrectTimeEntryCommandValidator(IStringLocalizer<ValidationMessages> localizer)
    {
        _ = RuleFor(x => x.TimeEntryId)
            .NotEmpty();

        _ = RuleFor(x => x.MandatoryReason)
            .NotEmpty()
            .WithMessage(localizer["MandatoryReasonRequired"])
            .MinimumLength(5)
            .WithMessage(localizer["MandatoryReasonRequired"]);

        _ = RuleFor(x => x.NewBreakMinutes)
            .GreaterThanOrEqualTo(0)
            .WithMessage(localizer["BreakDurationNegative"]);
    }
}
