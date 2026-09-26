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
    /// Gets the shipment notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the shipped quantity.
    /// </summary>
    public decimal Quantity { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the article is covered by warranty.
    /// </summary>
    public bool IsWarranty { get; protected set; }

    /// <summary>
    /// Gets the shipment identifier.
    /// </summary>
    public Guid ShipmentId { get; protected set; }

    /// <summary>
    /// Gets the article identifier.
    /// </summary>
    public Guid? ArticleId { get; protected set; }

    /// <summary>
    /// Gets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; protected set; }

    /// <summary>
    /// Gets the associated shipment.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Shipment? Shipment { get; protected set; }
}
