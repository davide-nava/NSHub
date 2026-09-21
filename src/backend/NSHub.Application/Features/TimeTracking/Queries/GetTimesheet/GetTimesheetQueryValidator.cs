// <copyright file="GetTimesheetQueryValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using Microsoft.Extensions.Localization;
using NSHub.Application.Resources;

namespace NSHub.Application.Features.TimeTracking.Queries.GetTimesheet;

/// <summary>
/// FluentValidation validator for GetTimesheetQuery.
/// </summary>
public class GetTimesheetQueryValidator : AbstractValidator<GetTimesheetQuery>
{
    public GetTimesheetQueryValidator(IStringLocalizer<ValidationMessages> localizer)
    {
        _ = RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage(localizer["EmployeeIdRequired"]);

        _ = RuleFor(x => x.EndDateUtc)
            .GreaterThanOrEqualTo(x => x.StartDateUtc)
            .WithMessage(localizer["GeneralError"]);
    }
}
