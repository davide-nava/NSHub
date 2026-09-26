// <copyright file="PriceListItem.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an item in a price list.
/// </summary>
public class PriceListItem : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the price list identifier.
    /// </summary>
    public Guid PriceListId { get; set; }

    /// <summary>
    /// Gets or sets the article identifier.
    /// </summary>
    public Guid ArticleId { get; set; }

    /// <summary>
    /// Gets or sets the price applied to the article.
    /// </summary>
    public decimal Price { get; set; }

    /// <summary>
    /// Gets or sets the minimum quantity required for this price.
    /// </summary>
    public decimal MinQuantity { get; set; }

    /// <summary>
    /// Gets or sets the discount percentage applied to the price.
    /// </summary>
    public decimal DiscountPercentage { get; set; }

    /// <summary>
    /// Gets or sets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; set; }

    /// <summary>
    /// Gets or sets the associated price list.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PriceList? PriceList { get; set; }
}
