using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class SalesInvoiceHeader : BaseEntity
{
    public int SalesInvoiceId { get; set; }

    public int CompanyId { get; set; }

    public string InvoiceNumber { get; set; } = null!;

    public DateOnly InvoiceDate { get; set; }

    public int CustomerId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public int? PaymentTermId { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal TotalTaxAmount { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Currency CurrencyCodeNavigation { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual PaymentTerm? PaymentTerm { get; set; }

    public virtual ICollection<SalesInvoiceLine> SalesInvoiceLines { get; set; } = [];
}
