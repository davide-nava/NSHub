using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EmployeeOnArticle : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public Guid ArticleId { get; set; }

    public decimal PriceCost { get; set; }

    public bool VatIncludedCost { get; set; }

    public decimal PriceSale { get; set; }

    public bool VatIncludedSale { get; set; }

    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public bool SetDiscountCost { get; set; }

    public bool SetDiscountSale { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual Article? Article { get; set; }

}
