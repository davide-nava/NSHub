using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PaymentModeDiscountDetail : BaseEntity
{

    public Guid PaymentModeId { get; set; }

    public decimal Discount { get; set; }

    // TODO: Check type
    public int ReferenceDate { get; set; }

    // TODO: Check type
    public int DaysForDiscount { get; set; }

    public virtual PaymentMode? PaymentMode { get; set; }

}
