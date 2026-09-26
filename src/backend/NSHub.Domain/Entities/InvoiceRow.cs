// <copyright file="InvoiceRow.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an invoice row.
/// </summary>
public class InvoiceRow : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the invoice year.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the invoice identifier.
    /// </summary>
    public Guid InvoiceId { get; set; }

    /// <summary>
    /// Gets or sets the article identifier.
    /// </summary>
    public Guid? ArticleId { get; set; }

    /// <summary>
    /// Gets or sets the article code.
    /// </summary>
    public string? ArticleCode { get; set; }

    /// <summary>
    /// Gets or sets the invoiced quantity.
    /// </summary>
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount percentage.
    /// </summary>
    public decimal DiscountPercentage { get; set; }

    /// <summary>
    /// Gets or sets the row amount.
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Gets or sets the VAT identifier.
    /// </summary>
    public Guid? VatId { get; set; }

    /// <summary>
    /// Gets or sets the line total amount.
    /// </summary>
    public decimal LineTotal { get; set; }

    /// <summary>
    /// Gets or sets the row description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the row number.
    /// </summary>
    public decimal? RowNumber { get; set; }

    /// <summary>
    /// Gets or sets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; set; }

    /// <summary>
    /// Gets or sets the associated invoice.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Invoice? Invoice { get; set; }

    /// <summary>
    /// Gets or sets the associated VAT rate.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Vat? Vat { get; set; }
}
