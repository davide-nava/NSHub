// <copyright file="CreatePageCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Cms.Commands.CreatePage;

using FluentValidation;

/// <summary>
/// Validator for <see cref="CreatePageCommand"/>.
/// </summary>
public sealed class CreatePageCommandValidator : AbstractValidator<CreatePageCommand>
{
    public CreatePageCommandValidator()
    {
        _ = RuleFor(x => x.Title)
            .NotEmpty().WithMessage("Page title is required.")
            .MaximumLength(200);

        _ = RuleFor(x => x.AuthorId)
            .NotEmpty().WithMessage("Author ID is required.");
    }
}
