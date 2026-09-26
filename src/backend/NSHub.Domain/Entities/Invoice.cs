// <copyright file="Invoice.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Invoice : AuditableTenantEntity
{
    public string InvoiceNumber { get; protected set; } = string.Empty;
    public int Year { get; protected set; }
    public DateTime? Date { get; protected set; }
    public Guid? InvoiceTypeId { get; protected set; }
    public Guid? CustomerId { get; protected set; }
    public Guid? SupplierId { get; protected set; }
    public bool IsPurchase { get; protected set; }
    public decimal? Amount { get; protected set; }
    public decimal? Quantity { get; protected set; }
    public decimal TotalTaxableAmount { get; protected set; }
    public decimal TotalVatAmount { get; protected set; }
    public string CurrencyCode { get; protected set; } = string.Empty;
    public decimal ExchangeRate { get; protected set; }
    public bool IsSplitPayment { get; protected set; }
    public string? SdiStatus { get; protected set; }
    public DateTime? InsertionDate { get; protected set; }
    public string? Notes { get; protected set; }
    public bool? IsClosed { get; protected set; }
    public Guid? VatId { get; protected set; }
    public Guid? PaymentId { get; protected set; }
    public DateTime? ClosingDate { get; protected set; }
    public string? DeliveryNoteReference { get; protected set; }
    public string? TheirReference { get; protected set; }
    public string? OurReference { get; protected set; }
    public string? OrderReference { get; protected set; }
    public virtual Customer? Customer { get; protected set; }
    public virtual InvoiceType? InvoiceType { get; protected set; }
    public virtual Payment? Payment { get; protected set; }
    public virtual Supplier? Supplier { get; protected set; }
    public virtual Vat? Vat { get; protected set; }

    private readonly List<InvoiceRow> _invoiceRows = new();
    public virtual IReadOnlyCollection<InvoiceRow> InvoiceRows => _invoiceRows.AsReadOnly();
    private readonly List<PaymentSchedule> _paymentSchedules = new();
    public virtual IReadOnlyCollection<PaymentSchedule> PaymentSchedules => _paymentSchedules.AsReadOnly();

    protected Invoice() { }

    public static Invoice Create()
    {
        return new Invoice();
    }
}
