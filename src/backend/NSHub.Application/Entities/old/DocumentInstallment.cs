using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class DocumentInstallment : BaseEntity
{
    public Guid DocumentId { get; set; }

    public DateTime InstallmentDate { get; set; }

    public decimal Amount { get; set; }

    public Guid LedgerId { get; set; }

    public decimal AmountPaid { get; set; }

    public bool IsEdited { get; set; }

    public virtual Document? Document { get; set; }
    public virtual Ledger? Ledger { get; set; }

}
