using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PurchaseReceiptHeader : BaseEntity
{
    public int PurchaseReceiptId { get; set; }

    public int CompanyId { get; set; }

    public string ReceiptNumber { get; set; } = null!;

    public DateOnly ReceiptDate { get; set; }

    public int SupplierId { get; set; }

    public int WarehouseId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<PurchaseReceiptLine> PurchaseReceiptLines { get; set; } = [];

    public virtual Supplier Supplier { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
