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
    /// Gets the invoice year.
    /// </summary>
    public int Year { get; protected set; }

    /// <summary>
    /// Gets the invoice identifier.
    /// </summary>
    public Guid InvoiceId { get; protected set; }

    /// <summary>
    /// Gets the article identifier.
    /// </summary>
    public Guid? ArticleId { get; protected set; }

    /// <summary>
    /// Gets the article code.
    /// </summary>
    public string? ArticleCode { get; protected set; }

    /// <summary>
    /// Gets the invoiced quantity.
    /// </summary>
    public decimal? Quantity { get; protected set; }

    /// <summary>
    /// Gets the unit price.
    /// </summary>
    public decimal UnitPrice { get; protected set; }

    /// <summary>
    /// Gets the discount percentage.
    /// </summary>
    public decimal DiscountPercentage { get; protected set; }

    /// <summary>
    /// Gets the row amount.
    /// </summary>
    public decimal? Amount { get; protected set; }

    /// <summary>
    /// Gets the VAT identifier.
    /// </summary>
    public Guid? VatId { get; protected set; }

    /// <summary>
    /// Gets the line total amount.
    /// </summary>
    public decimal LineTotal { get; protected set; }

    /// <summary>
    /// Gets the row description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the row number.
    /// </summary>
    public decimal? RowNumber { get; protected set; }

    /// <summary>
    /// Gets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; protected set; }

    /// <summary>
    /// Gets the associated invoice.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Invoice? Invoice { get; protected set; }

    /// <summary>
    /// Gets the associated VAT rate.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Vat? Vat { get; protected set; }
}
