using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class SupplierLedgerEntry : BaseEntity
{
    public int SupplierLedgerEntryId { get; set; }

    public int CompanyId { get; set; }

    public int SupplierId { get; set; }

    public string DocumentType { get; set; } = null!;

    public int DocumentId { get; set; }

    public DateOnly PostingDate { get; set; }

    public decimal Amount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public bool Open { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Currency CurrencyCodeNavigation { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
