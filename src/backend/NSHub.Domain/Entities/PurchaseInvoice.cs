// <copyright file="PurchaseInvoice.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a purchase invoice entity.
/// </summary>
public class PurchaseInvoice : BaseEntity
{
    /// <summary>Gets or sets the invoice code (composite key).</summary>
    public int CodInvoice { get; set; }

    /// <summary>Gets or sets the year (composite key).</summary>
    public int Year { get; set; }

    /// <summary>Gets or sets the invoice date.</summary>
    public DateTime? Date { get; set; }

    /// <summary>Gets or sets the supplier code.</summary>
    public int? CodSupplier { get; set; }

    /// <summary>Gets or sets the total amount.</summary>
    public decimal? Amount { get; set; }

    /// <summary>Gets or sets the quantity.</summary>
    public decimal? Quantity { get; set; }

    /// <summary>Gets or sets the insertion date.</summary>
    public DateTime? InsertionDate { get; set; }

    /// <summary>Gets or sets notes.</summary>
    public string? Notes { get; set; }

    /// <summary>Gets or sets a value indicating whether the invoice is closed/paid.</summary>
    public bool? IsClosed { get; set; }

    /// <summary>Gets or sets the VAT code.</summary>
    public int? CodVat { get; set; }

    /// <summary>Gets or sets the payment method code.</summary>
    public int? CodPayment { get; set; }

    /// <summary>Gets or sets the closing date.</summary>
    public DateTime? ClosingDate { get; set; }
}
