using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class PurchaseInvoiceHeader : BaseEntity
{
    public int PurchaseInvoiceId { get; set; }

    public int CompanyId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateOnly InvoiceDate { get; set; }

    public int SupplierId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public int? PaymentTermId { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal TotalTaxAmount { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Currency CurrencyCodeNavigation { get; set; } = null!;

    public virtual PaymentTerm? PaymentTerm { get; set; }

    public virtual ICollection<PurchaseInvoiceLine> PurchaseInvoiceLines { get; set; } = [];

    public virtual Supplier Supplier { get; set; } = null!;
}
