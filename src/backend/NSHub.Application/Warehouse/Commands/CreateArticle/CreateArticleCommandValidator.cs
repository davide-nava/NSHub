// <copyright file="CreateArticleCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Warehouse.Commands.CreateArticle;

using FluentValidation;

/// <summary>
/// Validator for <see cref="CreateArticleCommand"/>.
/// </summary>
public sealed class CreateArticleCommandValidator : AbstractValidator<CreateArticleCommand>
{
    public CreateArticleCommandValidator()
    {
        _ = RuleFor(x => x.Code)
            .NotEmpty().WithMessage("Article code is required.")
            .MaximumLength(50);

        _ = RuleFor(x => x.Name)
            .NotEmpty().WithMessage("Article name is required.")
            .MaximumLength(200);
    }
}
