// <copyright file="PublishPageCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Cms.Commands.PublishPage;

using FluentValidation;

/// <summary>
/// Validator for <see cref="PublishPageCommand"/>.
/// </summary>
public sealed class PublishPageCommandValidator : AbstractValidator<PublishPageCommand>
{
    public PublishPageCommandValidator()
    {
        _ = RuleFor(x => x.PageId).NotEmpty().WithMessage("Page ID is required.");
    }
}
