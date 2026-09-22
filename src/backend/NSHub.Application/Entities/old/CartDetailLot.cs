using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CartDetailLot : BaseEntity
{
    public Guid CartDetailId { get; set; }

    public string LotNumber { get; set; } = null!;

    public decimal Quantity { get; set; }

    public virtual CartDetail? CartDetail { get; set; }
}
