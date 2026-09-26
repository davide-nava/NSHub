// <copyright file="QuotationRow.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a quotation row.
/// </summary>
public class QuotationRow : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the quotation year.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the quotation identifier.
    /// </summary>
    public Guid QuotationId { get; set; }

    /// <summary>
    /// Gets or sets the article identifier.
    /// </summary>
    public Guid? ArticleId { get; set; }

    /// <summary>
    /// Gets or sets the article code.
    /// </summary>
    public string? ArticleCode { get; set; }

    /// <summary>
    /// Gets or sets the quoted quantity.
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
    /// Gets or sets the row description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the row refers to a sale.
    /// </summary>
    public bool IsSale { get; set; }

    /// <summary>
    /// Gets or sets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; set; }

    /// <summary>
    /// Gets or sets the associated quotation.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Quotation? Quotation { get; set; }
}
