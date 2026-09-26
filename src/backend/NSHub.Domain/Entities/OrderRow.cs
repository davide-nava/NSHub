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
    /// Gets or sets the order identifier.
    /// </summary>
    public Guid OrderId { get; set; }

    /// <summary>
    /// Gets or sets the row number.
    /// </summary>
    public int RowNumber { get; set; }

    /// <summary>
    /// Gets or sets the article identifier.
    /// </summary>
    public Guid? ArticleId { get; set; }

    /// <summary>
    /// Gets or sets the article code.
    /// </summary>
    public string? ArticleCode { get; set; }

    /// <summary>
    /// Gets or sets the row description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ordered quantity.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Gets or sets the delivered quantity.
    /// </summary>
    public decimal DeliveredQuantity { get; set; }

    /// <summary>
    /// Gets or sets the invoiced quantity.
    /// </summary>
    public decimal InvoicedQuantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price.
    /// </summary>
    public decimal UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the discount percentage.
    /// </summary>
    public decimal DiscountPercentage { get; set; }

    /// <summary>
    /// Gets or sets the line total amount.
    /// </summary>
    public decimal LineTotal { get; set; }

    /// <summary>
    /// Gets or sets the VAT identifier.
    /// </summary>
    public Guid? VatId { get; set; }

    /// <summary>
    /// Gets or sets the warehouse identifier.
    /// </summary>
    public Guid? WarehouseId { get; set; }

    /// <summary>
    /// Gets or sets the expected delivery date.
    /// </summary>
    public DateTime? ExpectedDeliveryDate { get; set; }

    /// <summary>
    /// Gets or sets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; set; }

    /// <summary>
    /// Gets or sets the associated order.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Order? Order { get; set; }

    /// <summary>
    /// Gets or sets the associated VAT rate.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Vat? Vat { get; set; }

    /// <summary>
    /// Gets or sets the associated warehouse.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Warehouse? Warehouse { get; set; }

    /// <summary>
    /// Gets or sets the stock movements associated with this order row.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<StockMovement> StockMovements { get; set; }
        = [];
}
