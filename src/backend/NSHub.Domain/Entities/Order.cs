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
    /// Gets the order number.
    /// </summary>
    public string OrderNumber { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the order year.
    /// </summary>
    public int Year { get; protected set; }

    /// <summary>
    /// Gets the order date.
    /// </summary>
    public DateTime Date { get; protected set; }

    /// <summary>
    /// Gets the order type.
    /// </summary>
    public string OrderType { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the customer identifier.
    /// </summary>
    public Guid? CustomerId { get; protected set; }

    /// <summary>
    /// Gets the supplier identifier.
    /// </summary>
    public Guid? SupplierId { get; protected set; }

    /// <summary>
    /// Gets the quotation identifier.
    /// </summary>
    public Guid? QuotationId { get; protected set; }

    /// <summary>
    /// Gets the payment term identifier.
    /// </summary>
    public Guid? PaymentId { get; protected set; }

    /// <summary>
    /// Gets the shipping address identifier.
    /// </summary>
    public Guid? ShippingAddressId { get; protected set; }

    /// <summary>
    /// Gets the order currency code.
    /// </summary>
    public string CurrencyCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the exchange rate.
    /// </summary>
    public decimal ExchangeRate { get; protected set; }

    /// <summary>
    /// Gets the total net amount.
    /// </summary>
    public decimal TotalNetAmount { get; protected set; }

    /// <summary>
    /// Gets the total VAT amount.
    /// </summary>
    public decimal TotalVatAmount { get; protected set; }

    /// <summary>
    /// Gets the total gross amount.
    /// </summary>
    public decimal TotalGrossAmount { get; protected set; }

    /// <summary>
    /// Gets the order status code.
    /// </summary>
    public string StatusCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets additional notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; protected set; }

    /// <summary>
    /// Gets the associated payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Payment? Payment { get; protected set; }

    /// <summary>
    /// Gets the originating quotation.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Quotation? Quotation { get; protected set; }

    /// <summary>
    /// Gets the associated supplier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Supplier? Supplier { get; protected set; }

    /// <summary>
    /// Gets the rows associated with this order.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<OrderRow> OrderRows { get; protected set; }
        = new List<OrderRow>();
}
