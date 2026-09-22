using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class Supplier : BaseEntity
{
    public int SupplierId { get; set; }

    public int CompanyId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? VatNumber { get; set; }

    public string? FiscalCode { get; set; }

    public int? AddressId { get; set; }

    public int? PaymentTermId { get; set; }

    public bool IsActive { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<GlJournalLine> GlJournalLines { get; set; } = [];

    public virtual PaymentTerm? PaymentTerm { get; set; }

    public virtual ICollection<PurchaseInvoiceHeader> PurchaseInvoiceHeaders { get; set; } = [];

    public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = [];

    public virtual ICollection<PurchaseReceiptHeader> PurchaseReceiptHeaders { get; set; } = [];
    public virtual ICollection<SupplierLedgerEntry> SupplierLedgerEntries { get; set; } = [];
}
