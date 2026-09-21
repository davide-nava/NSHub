using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PaymentOrderDetail : BaseEntity
{

    public Guid LedgerId { get; set; }

    public Guid LedgerBodyId { get; set; }

    public Guid PaymentOrderRowId { get; set; }

    public decimal AmountDocumentCurrency { get; set; }

    public decimal Discount { get; set; }

    public Guid LedgerBodyDiscountId { get; set; }

    public Guid CreditingLedgerBodyId { get; set; }

    public bool IsDiscount { get; set; }

    public decimal Starling { get; set; }

    public virtual Ledger? Ledger { get; set; }
    public virtual LedgerBody? LedgerBody { get; set; }
    public virtual PaymentOrderRow? PaymentOrderRow { get; set; }
    public virtual LedgerBodyDiscount? LedgerBodyDiscount { get; set; }
    public virtual CreditingLedgerBody? CreditingLedgerBody { get; set; }
}
