// <copyright file="Order.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a sales or purchase order.
/// </summary>
public class Order : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the order number.
    /// </summary>
    public string OrderNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the order year.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the order date.
    /// </summary>
    public DateTime Date { get; set; }

    /// <summary>
    /// Gets or sets the order type.
    /// </summary>
    public string OrderType { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the customer identifier.
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the supplier identifier.
    /// </summary>
    public Guid? SupplierId { get; set; }

    /// <summary>
    /// Gets or sets the quotation identifier.
    /// </summary>
    public Guid? QuotationId { get; set; }

    /// <summary>
    /// Gets or sets the payment term identifier.
    /// </summary>
    public Guid? PaymentId { get; set; }

    /// <summary>
    /// Gets or sets the shipping address identifier.
    /// </summary>
    public Guid? ShippingAddressId { get; set; }

    /// <summary>
    /// Gets or sets the order currency code.
    /// </summary>
    public string CurrencyCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the exchange rate.
    /// </summary>
    public decimal ExchangeRate { get; set; }

    /// <summary>
    /// Gets or sets the total net amount.
    /// </summary>
    public decimal TotalNetAmount { get; set; }

    /// <summary>
    /// Gets or sets the total VAT amount.
    /// </summary>
    public decimal TotalVatAmount { get; set; }

    /// <summary>
    /// Gets or sets the total gross amount.
    /// </summary>
    public decimal TotalGrossAmount { get; set; }

    /// <summary>
    /// Gets or sets the order status code.
    /// </summary>
    public string StatusCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; set; }

    /// <summary>
    /// Gets or sets the associated payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Payment? Payment { get; set; }

    /// <summary>
    /// Gets or sets the originating quotation.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Quotation? Quotation { get; set; }

    /// <summary>
    /// Gets or sets the associated supplier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Supplier? Supplier { get; set; }

    /// <summary>
    /// Gets or sets the rows associated with this order.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<OrderRow> OrderRows { get; set; }
        = [];
}
