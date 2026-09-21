// <copyright file="IssueInvoiceCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Invoicing.Commands.IssueInvoice;

using FluentValidation;

/// <summary>
/// Validator for <see cref="IssueInvoiceCommand"/>.
/// </summary>
public sealed class IssueInvoiceCommandValidator : AbstractValidator<IssueInvoiceCommand>
{
    public IssueInvoiceCommandValidator()
    {
        _ = RuleFor(x => x.InvoiceId).NotEmpty().WithMessage("Invoice ID is required.");
    }
}
