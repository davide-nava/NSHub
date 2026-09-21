using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class InventoryBalance : BaseEntity
{
    public int InventoryBalanceId { get; set; }

    public int ItemId { get; set; }

    public int WarehouseId { get; set; }

    public int? LocationId { get; set; }

    public decimal QuantityOnHand { get; set; }

    public decimal QuantityReserved { get; set; }

    public decimal QuantityOnOrder { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual Location? Location { get; set; }

    public virtual Warehouse Warehouse { get; set; } = null!;
}
