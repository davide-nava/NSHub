// <copyright file="Order.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Order : AuditableTenantEntity
{
    public string OrderNumber { get; protected set; } = string.Empty;
    public int Year { get; protected set; }
    public DateTime Date { get; protected set; }
    public string OrderType { get; protected set; } = string.Empty;
    public Guid? CustomerId { get; protected set; }
    public Guid? SupplierId { get; protected set; }
    public Guid? QuotationId { get; protected set; }
    public Guid? PaymentId { get; protected set; }
    public Guid? ShippingAddressId { get; protected set; }
    public string CurrencyCode { get; protected set; } = string.Empty;
    public decimal ExchangeRate { get; protected set; }
    public decimal TotalNetAmount { get; protected set; }
    public decimal TotalVatAmount { get; protected set; }
    public decimal TotalGrossAmount { get; protected set; }
    public string StatusCode { get; protected set; } = string.Empty;
    public string? Notes { get; protected set; }
    public virtual Customer? Customer { get; protected set; }
    public virtual Payment? Payment { get; protected set; }
    public virtual Quotation? Quotation { get; protected set; }
    public virtual Supplier? Supplier { get; protected set; }

    private readonly List<DeliveryNote> _deliveryNotes = new();
    public virtual IReadOnlyCollection<DeliveryNote> DeliveryNotes => _deliveryNotes.AsReadOnly();
    private readonly List<OrderRow> _orderRows = new();
    public virtual IReadOnlyCollection<OrderRow> OrderRows => _orderRows.AsReadOnly();

    protected Order() { }

    public static Order Create(
        string orderNumber,
        int year,
        DateTime date,
        string orderType,
        Guid? customerId,
        string currencyCode = "EUR",
        decimal totalGrossAmount = 0m,
        string statusCode = "Draft")
    {
        return new Order
        {
            OrderNumber = orderNumber,
            Year = year,
            Date = date,
            OrderType = orderType,
            CustomerId = customerId,
            CurrencyCode = currencyCode,
            TotalGrossAmount = totalGrossAmount,
            StatusCode = statusCode
        };
    }

    public void UpdateStatus(string newStatusCode)
    {
        StatusCode = newStatusCode;
    }

    public void UpdateTotals(decimal net, decimal vat, decimal gross)
    {
        TotalNetAmount = net;
        TotalVatAmount = vat;
        TotalGrossAmount = gross;
    }
}
