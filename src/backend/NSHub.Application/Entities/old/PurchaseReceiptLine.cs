using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PurchaseReceiptLine : BaseEntity
{
    public int PurchaseReceiptLineId { get; set; }

    public int PurchaseReceiptId { get; set; }

    public int? PurchaseOrderLineId { get; set; }

    public int ItemId { get; set; }

    public decimal ReceivedQuantity { get; set; }

    public int UomId { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual PurchaseOrderLine? PurchaseOrderLine { get; set; }

    public virtual PurchaseReceiptHeader PurchaseReceipt { get; set; } = null!;

    public virtual UnitOfMeasure Uom { get; set; } = null!;
}
