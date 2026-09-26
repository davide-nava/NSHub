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
    /// Gets the quotation year.
    /// </summary>
    public int Year { get; protected set; }

    /// <summary>
    /// Gets the quotation identifier.
    /// </summary>
    public Guid QuotationId { get; protected set; }

    /// <summary>
    /// Gets the article identifier.
    /// </summary>
    public Guid? ArticleId { get; protected set; }

    /// <summary>
    /// Gets the article code.
    /// </summary>
    public string? ArticleCode { get; protected set; }

    /// <summary>
    /// Gets the quoted quantity.
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
    /// Gets the row description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the row refers to a sale.
    /// </summary>
    public bool IsSale { get; protected set; }

    /// <summary>
    /// Gets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; protected set; }

    /// <summary>
    /// Gets the associated quotation.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Quotation? Quotation { get; protected set; }
}
