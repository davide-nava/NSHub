using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class PriceListItem : AuditableTenantEntity
{
    public Guid PriceListId { get; protected set; }
    public Guid ArticleId { get; protected set; }
    public decimal Price { get; protected set; }
    public decimal MinQuantity { get; protected set; }
    public decimal DiscountPercentage { get; protected set; }
    public virtual Article? Article { get; protected set; }
    public virtual PriceList? PriceList { get; protected set; }

    protected PriceListItem() { }

    public static PriceListItem Create()
    {
        return new PriceListItem();
    }
}
