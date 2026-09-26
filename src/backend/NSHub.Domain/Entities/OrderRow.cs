// <copyright file="OrderRow.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an order row.
/// </summary>
public class OrderRow : AuditableTenantEntity
{
    /// <summary>
    /// Gets the order identifier.
    /// </summary>
    public Guid OrderId { get; protected set; }

    /// <summary>
    /// Gets the row number.
    /// </summary>
    public int RowNumber { get; protected set; }

    /// <summary>
    /// Gets the article identifier.
    /// </summary>
    public Guid? ArticleId { get; protected set; }

    /// <summary>
    /// Gets the article code.
    /// </summary>
    public string? ArticleCode { get; protected set; }

    /// <summary>
    /// Gets the row description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the ordered quantity.
    /// </summary>
    public decimal Quantity { get; protected set; }

    /// <summary>
    /// Gets the delivered quantity.
    /// </summary>
    public decimal DeliveredQuantity { get; protected set; }

    /// <summary>
    /// Gets the invoiced quantity.
    /// </summary>
    public decimal InvoicedQuantity { get; protected set; }

    /// <summary>
    /// Gets the unit price.
    /// </summary>
    public decimal UnitPrice { get; protected set; }

    /// <summary>
    /// Gets the discount percentage.
    /// </summary>
    public decimal DiscountPercentage { get; protected set; }

    /// <summary>
    /// Gets the line total amount.
    /// </summary>
    public decimal LineTotal { get; protected set; }

    /// <summary>
    /// Gets the VAT identifier.
    /// </summary>
    public Guid? VatId { get; protected set; }

    /// <summary>
    /// Gets the warehouse identifier.
    /// </summary>
    public Guid? WarehouseId { get; protected set; }

    /// <summary>
    /// Gets the expected delivery date.
    /// </summary>
    public DateTime? ExpectedDeliveryDate { get; protected set; }

    /// <summary>
    /// Gets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; protected set; }

    /// <summary>
    /// Gets the associated order.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Order? Order { get; protected set; }

    /// <summary>
    /// Gets the associated VAT rate.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Vat? Vat { get; protected set; }

    /// <summary>
    /// Gets the associated warehouse.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Warehouse? Warehouse { get; protected set; }

    /// <summary>
    /// Gets the stock movements associated with this order row.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<StockMovement> StockMovements { get; protected set; }
        = new List<StockMovement>();
}
