// <copyright file="Invoice.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an invoice.
/// </summary>
public class Invoice : AuditableTenantEntity
{
    /// <summary>
    /// Gets the invoice number.
    /// </summary>
    public string InvoiceNumber { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the invoice year.
    /// </summary>
    public int Year { get; protected set; }

    /// <summary>
    /// Gets the invoice date.
    /// </summary>
    public DateTime? Date { get; protected set; }

    /// <summary>
    /// Gets the invoice type identifier.
    /// </summary>
    public Guid? InvoiceTypeId { get; protected set; }

    /// <summary>
    /// Gets the customer identifier.
    /// </summary>
    public Guid? CustomerId { get; protected set; }

    /// <summary>
    /// Gets the supplier identifier.
    /// </summary>
    public Guid? SupplierId { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the invoice is a purchase invoice.
    /// </summary>
    public bool IsPurchase { get; protected set; }

    /// <summary>
    /// Gets the invoice amount.
    /// </summary>
    public decimal? Amount { get; protected set; }

    /// <summary>
    /// Gets the total quantity.
    /// </summary>
    public decimal? Quantity { get; protected set; }

    /// <summary>
    /// Gets the total taxable amount.
    /// </summary>
    public decimal TotalTaxableAmount { get; protected set; }

    /// <summary>
    /// Gets the total VAT amount.
    /// </summary>
    public decimal TotalVatAmount { get; protected set; }

    /// <summary>
    /// Gets the currency code.
    /// </summary>
    public string CurrencyCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the exchange rate.
    /// </summary>
    public decimal ExchangeRate { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether split payment is enabled.
    /// </summary>
    public bool IsSplitPayment { get; protected set; }

    /// <summary>
    /// Gets the SDI status.
    /// </summary>
    public string? SdiStatus { get; protected set; }

    /// <summary>
    /// Gets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; protected set; }

    /// <summary>
    /// Gets additional notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the invoice is closed.
    /// </summary>
    public bool? IsClosed { get; protected set; }

    /// <summary>
    /// Gets the VAT identifier.
    /// </summary>
    public Guid? VatId { get; protected set; }

    /// <summary>
    /// Gets the payment term identifier.
    /// </summary>
    public Guid? PaymentId { get; protected set; }

    /// <summary>
    /// Gets the invoice closing date.
    /// </summary>
    public DateTime? ClosingDate { get; protected set; }

    /// <summary>
    /// Gets the delivery note reference.
    /// </summary>
    public string? DeliveryNoteReference { get; protected set; }

    /// <summary>
    /// Gets the customer reference.
    /// </summary>
    public string? TheirReference { get; protected set; }

    /// <summary>
    /// Gets our reference.
    /// </summary>
    public string? OurReference { get; protected set; }

    /// <summary>
    /// Gets the order reference.
    /// </summary>
    public string? OrderReference { get; protected set; }

    /// <summary>
    /// Gets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; protected set; }

    /// <summary>
    /// Gets the associated invoice type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual InvoiceType? InvoiceType { get; protected set; }

    /// <summary>
    /// Gets the associated payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Payment? Payment { get; protected set; }

    /// <summary>
    /// Gets the associated supplier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Supplier? Supplier { get; protected set; }

    /// <summary>
    /// Gets the associated VAT rate.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Vat? Vat { get; protected set; }

    /// <summary>
    /// Gets the invoice rows associated with this invoice.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<InvoiceRow> InvoiceRows { get; protected set; }
        = new List<InvoiceRow>();

    /// <summary>
    /// Gets the payment schedules associated with this invoice.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<PaymentSchedule> PaymentSchedules { get; protected set; }
        = new List<PaymentSchedule>();

    /// <summary>
    /// Gets the documents associated with this invoice.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Document> Documents { get; protected set; }
        = new List<Document>();
}
