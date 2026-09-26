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
    /// Gets or sets the invoice number.
    /// </summary>
    public string InvoiceNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the invoice year.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the invoice date.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Gets or sets the invoice type identifier.
    /// </summary>
    public Guid? InvoiceTypeId { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier.
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the supplier identifier.
    /// </summary>
    public Guid? SupplierId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the invoice is a purchase invoice.
    /// </summary>
    public bool IsPurchase { get; set; }

    /// <summary>
    /// Gets or sets the invoice amount.
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Gets or sets the total quantity.
    /// </summary>
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Gets or sets the total taxable amount.
    /// </summary>
    public decimal TotalTaxableAmount { get; set; }

    /// <summary>
    /// Gets or sets the total VAT amount.
    /// </summary>
    public decimal TotalVatAmount { get; set; }

    /// <summary>
    /// Gets or sets the currency code.
    /// </summary>
    public string CurrencyCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the exchange rate.
    /// </summary>
    public decimal ExchangeRate { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether split payment is enabled.
    /// </summary>
    public bool IsSplitPayment { get; set; }

    /// <summary>
    /// Gets or sets the SDI status.
    /// </summary>
    public string? SdiStatus { get; set; }

    /// <summary>
    /// Gets or sets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; set; }

    /// <summary>
    /// Gets or sets additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the invoice is closed.
    /// </summary>
    public bool? IsClosed { get; set; }

    /// <summary>
    /// Gets or sets the VAT identifier.
    /// </summary>
    public Guid? VatId { get; set; }

    /// <summary>
    /// Gets or sets the payment term identifier.
    /// </summary>
    public Guid? PaymentId { get; set; }

    /// <summary>
    /// Gets or sets the invoice closing date.
    /// </summary>
    public DateTime? ClosingDate { get; set; }

    /// <summary>
    /// Gets or sets the delivery note reference.
    /// </summary>
    public string? DeliveryNoteReference { get; set; }

    /// <summary>
    /// Gets or sets the customer reference.
    /// </summary>
    public string? TheirReference { get; set; }

    /// <summary>
    /// Gets or sets our reference.
    /// </summary>
    public string? OurReference { get; set; }

    /// <summary>
    /// Gets or sets the order reference.
    /// </summary>
    public string? OrderReference { get; set; }

    /// <summary>
    /// Gets or sets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; set; }

    /// <summary>
    /// Gets or sets the associated invoice type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual InvoiceType? InvoiceType { get; set; }

    /// <summary>
    /// Gets or sets the associated payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Payment? Payment { get; set; }

    /// <summary>
    /// Gets or sets the associated supplier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Supplier? Supplier { get; set; }

    /// <summary>
    /// Gets or sets the associated VAT rate.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Vat? Vat { get; set; }

    /// <summary>
    /// Gets or sets the invoice rows associated with this invoice.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<InvoiceRow> InvoiceRows { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the payment schedules associated with this invoice.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<PaymentSchedule> PaymentSchedules { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the documents associated with this invoice.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Document> Documents { get; set; }
        = [];
}
