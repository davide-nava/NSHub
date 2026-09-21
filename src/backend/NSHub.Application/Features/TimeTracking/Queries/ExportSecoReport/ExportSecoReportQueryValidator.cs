// <copyright file="ExportSecoReportQueryValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using Microsoft.Extensions.Localization;
using NSHub.Application.Resources;

namespace NSHub.Application.Features.TimeTracking.Queries.ExportSecoReport;

/// <summary>
/// FluentValidation validator for ExportSecoReportQuery.
/// </summary>
public class ExportSecoReportQueryValidator : AbstractValidator<ExportSecoReportQuery>
{
    public ExportSecoReportQueryValidator(IStringLocalizer<ValidationMessages> localizer)
    {
        _ = RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage(localizer["EmployeeIdRequired"]);

        _ = RuleFor(x => x.Year)
            .InclusiveBetween(2000, 2100)
            .WithMessage(localizer["GeneralError"]);

        _ = RuleFor(x => x.Month)
            .InclusiveBetween(1, 12)
            .WithMessage(localizer["GeneralError"]);
    }
}
