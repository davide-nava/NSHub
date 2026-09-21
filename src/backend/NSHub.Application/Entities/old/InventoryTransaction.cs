using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class InventoryTransaction : BaseEntity
{
    public int InventoryTransactionId { get; set; }

    public int ItemId { get; set; }

    public int WarehouseId { get; set; }

    public int? LocationId { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal Quantity { get; set; }

    public string TransactionType { get; set; } = null!;

    public string? ReferenceDocumentType { get; set; }

    public int? ReferenceDocumentId { get; set; }

    public decimal? UnitCost { get; set; }

    public int CreatedByUserId { get; set; }

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual Item Item { get; set; } = null!;

    public virtual Location? Location { get; set; }

    public virtual Warehouse Warehouse { get; set; } = null!;
}
