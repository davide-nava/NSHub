// <copyright file="InvoiceLine.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Invoicing.Entities;

using NSHub.Domain.Common;
using NSHub.Domain.Exceptions;
using NSHub.Domain.Invoicing.ValueObjects;

/// <summary>
/// Domain entity representing an individual itemized line in a sales invoice.
/// </summary>
public class InvoiceLine : Entity<InvoiceLineId>
{
    /// <summary>
    /// Gets the parent invoice identifier.
    /// </summary>
    public InvoiceId InvoiceId { get; private set; }

    /// <summary>
    /// Gets the item or service description.
    /// </summary>
    public string Description { get; private set; } = string.Empty;

    /// <summary>
    /// Gets the billed quantity.
    /// </summary>
    public decimal Quantity { get; private set; }

    /// <summary>
    /// Gets the net unit price.
    /// </summary>
    public decimal UnitPrice { get; private set; }

    /// <summary>
    /// Gets the line discount percentage (0 to 100).
    /// </summary>
    public decimal DiscountPercentage { get; private set; }

    /// <summary>
    /// Gets the applicable VAT rate percentage.
    /// </summary>
    public decimal VatRate { get; private set; }

    /// <summary>
    /// Gets the computed net total after discount.
    /// </summary>
    public decimal LineTotalNet => Math.Round(Quantity * UnitPrice * (1m - (DiscountPercentage / 100m)), 2, MidpointRounding.AwayFromZero);

    /// <summary>
    /// Gets the computed VAT amount.
    /// </summary>
    public decimal LineTotalVat => Math.Round(LineTotalNet * (VatRate / 100m), 2, MidpointRounding.AwayFromZero);

    /// <summary>
    /// Gets the computed gross total (net + VAT).
    /// </summary>
    public decimal LineTotalGross => LineTotalNet + LineTotalVat;

    // Parameterless constructor for EF Core
    private InvoiceLine()
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="InvoiceLine"/> class.
    /// </summary>
    public InvoiceLine(
        InvoiceLineId id,
        InvoiceId invoiceId,
        string description,
        decimal quantity,
        decimal unitPrice,
        decimal discountPercentage,
        decimal vatRate)
    {
        if (string.IsNullOrWhiteSpace(description))
        {
            throw new BusinessRuleValidationException("InvoiceLine.DescriptionRequired", "Line description is mandatory.");
        }

        if (quantity <= 0)
        {
            throw new BusinessRuleValidationException("InvoiceLine.InvalidQuantity", "Line quantity must be greater than zero.");
        }

        if (unitPrice < 0)
        {
            throw new BusinessRuleValidationException("InvoiceLine.InvalidPrice", "Line unit price cannot be negative.");
        }

        if (discountPercentage is < 0 or > 100)
        {
            throw new BusinessRuleValidationException("InvoiceLine.InvalidDiscount", "Discount percentage must be between 0 and 100.");
        }

        if (vatRate < 0)
        {
            throw new BusinessRuleValidationException("InvoiceLine.InvalidVat", "VAT rate cannot be negative.");
        }

        Id = id.Value == Guid.Empty ? InvoiceLineId.New() : id;
        InvoiceId = invoiceId;
        Description = description.Trim();
        Quantity = quantity;
        UnitPrice = unitPrice;
        DiscountPercentage = discountPercentage;
        VatRate = vatRate;
    }
}
