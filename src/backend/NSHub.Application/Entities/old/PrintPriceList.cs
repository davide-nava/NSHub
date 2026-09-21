using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PrintPriceList : BaseEntity
{
    // TODO: Check type
    public int BulkNumber { get; set; }

    public Guid CorrespondentId { get; set; }

    public Guid ArticleId { get; set; }

    public Guid DiscountClassId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public IEnumerable<DecimalList> Discounts { get; set; }

    public decimal NetPrice { get; set; }

    public Guid PriceCalculationSourceId { get; set; }

    public virtual Correspondent? Correspondent { get; set; }
    public virtual Article? Article { get; set; }
    public virtual DiscountClass? DiscountClass { get; set; }
    public virtual PriceCalculationSource? PriceCalculationSource { get; set; }


}
