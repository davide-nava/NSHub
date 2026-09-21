// <copyright file="CreateInvoiceCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Invoicing.Commands.CreateInvoice;

using FluentValidation;

/// <summary>
/// Validator for <see cref="CreateInvoiceCommand"/>.
/// </summary>
public sealed class CreateInvoiceCommandValidator : AbstractValidator<CreateInvoiceCommand>
{
    public CreateInvoiceCommandValidator()
    {
        _ = RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Customer ID is required.");
    }
}
