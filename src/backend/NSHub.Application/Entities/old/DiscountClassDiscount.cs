using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class DiscountClassDiscount : BaseEntity
{
    public Guid DiscountClassId { get; set; }

    public decimal Discount { get; set; }

    public virtual DiscountClass? DiscountClass { get; set; }

}
