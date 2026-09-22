using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class DeductionDocumentLedger : BaseEntity
{
    public Guid DocumentId { get; set; }

    public Guid LedgerId { get; set; }

    public decimal Amount { get; set; }

    public virtual Ledger? Ledger { get; set; }
    public virtual Document? Document { get; set; }

}
