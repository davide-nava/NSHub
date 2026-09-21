// <copyright file="AddInvoiceLineCommandValidator.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Invoicing.Commands.AddInvoiceLine;

using FluentValidation;

/// <summary>
/// Validator for <see cref="AddInvoiceLineCommand"/>.
/// </summary>
public sealed class AddInvoiceLineCommandValidator : AbstractValidator<AddInvoiceLineCommand>
{
    public AddInvoiceLineCommandValidator()
    {
        _ = RuleFor(x => x.InvoiceId).NotEmpty().WithMessage("Invoice ID is required.");
        _ = RuleFor(x => x.Description).NotEmpty().MaximumLength(500);
        _ = RuleFor(x => x.Quantity).GreaterThan(0).WithMessage("Quantity must be greater than zero.");
        _ = RuleFor(x => x.UnitPrice).GreaterThanOrEqualTo(0).WithMessage("Unit price cannot be negative.");
        _ = RuleFor(x => x.DiscountPercentage).InclusiveBetween(0, 100).WithMessage("Discount must be between 0 and 100.");
        _ = RuleFor(x => x.VatRate).GreaterThanOrEqualTo(0).WithMessage("VAT rate cannot be negative.");
    }
}
