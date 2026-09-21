// <copyright file="GetCurrentStatusQueryValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using Microsoft.Extensions.Localization;
using NSHub.Application.Resources;

namespace NSHub.Application.Features.TimeTracking.Queries.GetCurrentStatus;

/// <summary>
/// FluentValidation validator for GetCurrentStatusQuery.
/// </summary>
public class GetCurrentStatusQueryValidator : AbstractValidator<GetCurrentStatusQuery>
{
    public GetCurrentStatusQueryValidator(IStringLocalizer<ValidationMessages> localizer)
    {
        _ = RuleFor(x => x.EmployeeId)
            .NotEmpty()
            .WithMessage(localizer["EmployeeIdRequired"]);
    }
}
