// <copyright file="GetEmployeeByIdQueryValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using FluentValidation;
using Microsoft.Extensions.Localization;
using NSHub.Application.Resources;

namespace NSHub.Application.Features.Employees.Queries.GetEmployeeById;

/// <summary>
/// FluentValidation validator for GetEmployeeByIdQuery.
/// </summary>
public class GetEmployeeByIdQueryValidator : AbstractValidator<GetEmployeeByIdQuery>
{
    public GetEmployeeByIdQueryValidator(IStringLocalizer<ValidationMessages> localizer)
    {
        _ = RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage(localizer["EmployeeIdRequired"]);
    }
}
