using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class RentalArticle : BaseEntity
{

    public Guid RentalId { get; set; }

    public Guid ArticleId { get; set; }

    public Guid WarehouseId { get; set; }

    public decimal Quantity { get; set; }

    public virtual Rental? Rental { get; set; }
    public virtual Article? Article { get; set; }
    public virtual Warehouse? Warehouse { get; set; }

}
