// <copyright file="InvoiceLine.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Domain entity representing an individual itemized line in a sales invoice.
/// </summary>
public class InvoiceLine : BaseEntity
{
    /// <summary>
    /// Gets the parent invoice identifier.
    /// </summary>
    public Guid InvoiceId { get; set; }

    /// <summary>
    /// Gets the item or service description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets the billed quantity.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Gets the net unit price.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets the line discount percentage (0 to 100).
    /// </summary>
    public decimal DiscountPercentage { get; set; }

    /// <summary>
    /// Gets the applicable VAT rate percentage.
    /// </summary>
    public decimal VatRate { get; set; }

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
}
