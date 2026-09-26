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
    /// Gets the price list identifier.
    /// </summary>
    public Guid PriceListId { get; protected set; }

    /// <summary>
    /// Gets the article identifier.
    /// </summary>
    public Guid ArticleId { get; protected set; }

    /// <summary>
    /// Gets the price applied to the article.
    /// </summary>
    public decimal Price { get; protected set; }

    /// <summary>
    /// Gets the minimum quantity required for this price.
    /// </summary>
    public decimal MinQuantity { get; protected set; }

    /// <summary>
    /// Gets the discount percentage applied to the price.
    /// </summary>
    public decimal DiscountPercentage { get; protected set; }

    /// <summary>
    /// Gets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; protected set; }

    /// <summary>
    /// Gets the associated price list.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PriceList? PriceList { get; protected set; }
}
