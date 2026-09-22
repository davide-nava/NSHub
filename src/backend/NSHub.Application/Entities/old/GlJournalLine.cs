using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class GlJournalLine : BaseEntity
{
    public int GlJournalLineId { get; set; }

    public int GlJournalId { get; set; }

    public int LineNumber { get; set; }

    public int GlAccountId { get; set; }

    public int? BusinessUnitId { get; set; }

    public int? CustomerId { get; set; }

    public int? SupplierId { get; set; }

    public decimal DebitAmount { get; set; }

    public decimal CreditAmount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public decimal ExchangeRate { get; set; }

    public string? ReferenceDocumentType { get; set; }

    public int? ReferenceDocumentId { get; set; }

    public virtual BusinessUnit? BusinessUnit { get; set; }

    public virtual Currency CurrencyCodeNavigation { get; set; } = null!;

    public virtual Customer? Customer { get; set; }

    public virtual GlAccount GlAccount { get; set; } = null!;

    public virtual GlJournalHeader GlJournal { get; set; } = null!;

    public virtual Supplier? Supplier { get; set; }
}
