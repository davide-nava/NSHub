using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class Location : BaseEntity
{
    public int LocationId { get; set; }

    public int WarehouseId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string LocationType { get; set; } = null!;

    public virtual ICollection<InventoryBalance> InventoryBalances { get; set; } = [];

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = [];

    public virtual Warehouse Warehouse { get; set; } = null!;
}
