// <copyright file="ShipmentArticle.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an article shipped as part of a shipment.
/// </summary>
public class ShipmentArticle : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the shipment notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the shipped quantity.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the article is covered by warranty.
    /// </summary>
    public bool IsWarranty { get; set; }

    /// <summary>
    /// Gets or sets the shipment identifier.
    /// </summary>
    public Guid ShipmentId { get; set; }

    /// <summary>
    /// Gets or sets the article identifier.
    /// </summary>
    public Guid? ArticleId { get; set; }

    /// <summary>
    /// Gets or sets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; set; }

    /// <summary>
    /// Gets or sets the associated shipment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Shipment? Shipment { get; set; }
}
