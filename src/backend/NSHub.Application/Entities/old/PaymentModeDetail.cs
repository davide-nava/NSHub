using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class PaymentModeDetail : BaseEntity
{

    public Guid PaymentModeId { get; set; }

    public int Days { get; set; }

    public ExpiringType ExpiringType { get; set; }

    public decimal Percentage { get; set; }

    public decimal CreditorsRounding { get; set; }

    public decimal DebtorsTolerance { get; set; }

    public virtual PaymentMode? PaymentMode { get; set; }

}
