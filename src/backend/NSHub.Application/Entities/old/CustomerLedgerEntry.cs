using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CustomerLedgerEntry : BaseEntity
{
    public int CustomerLedgerEntryId { get; set; }

    public int CompanyId { get; set; }

    public int CustomerId { get; set; }

    public string DocumentType { get; set; } = null!;

    public int DocumentId { get; set; }

    public DateOnly PostingDate { get; set; }

    public decimal Amount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public bool Open { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual Currency CurrencyCodeNavigation { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;
}
