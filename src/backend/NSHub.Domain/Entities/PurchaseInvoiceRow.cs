// <copyright file="PurchaseInvoiceRow.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a line item in a purchase invoice.
/// </summary>
public class PurchaseInvoiceRow : BaseEntity
{
    /// <summary>Gets or sets the invoice row code (composite key).</summary>
    public int CodInvoiceRow { get; set; }

    /// <summary>Gets or sets the year (composite key).</summary>
    public int Year { get; set; }

    /// <summary>Gets or sets the article code.</summary>
    public string? CodArticle { get; set; }

    /// <summary>Gets or sets the invoice code (composite key).</summary>
    public int CodInvoice { get; set; }

    /// <summary>Gets or sets the quantity.</summary>
    public decimal? Quantity { get; set; }

    /// <summary>Gets or sets the amount/price.</summary>
    public decimal? Amount { get; set; }

    /// <summary>Gets or sets the description.</summary>
    public string? Description { get; set; }

    /// <summary>Gets or sets the insertion date.</summary>
    public DateTime? InsertionDate { get; set; }

    /// <summary>Gets or sets the row sequence number.</summary>
    public decimal? RowNumber { get; set; }
}
