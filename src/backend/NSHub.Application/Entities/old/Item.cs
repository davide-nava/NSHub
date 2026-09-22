using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class Item : BaseEntity
{
    public int ItemId { get; set; }

    public int CompanyId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string ItemType { get; set; } = null!;

    public int BaseUomId { get; set; }

    public int ItemGroupId { get; set; }

    public bool IsStockManaged { get; set; }

    public bool IsActive { get; set; }

    public virtual UnitOfMeasure BaseUom { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<InventoryBalance> InventoryBalances { get; set; } = [];

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = [];

    public virtual ItemGroup ItemGroup { get; set; } = null!;

    public virtual ICollection<ItemUomConversion> ItemUomConversions { get; set; } = [];
    public virtual ICollection<PurchaseInvoiceLine> PurchaseInvoiceLines { get; set; } = [];

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = [];

    public virtual ICollection<PurchaseReceiptLine> PurchaseReceiptLines { get; set; } = [];
    public virtual ICollection<SalesInvoiceLine> SalesInvoiceLines { get; set; } = [];

    public virtual ICollection<SalesOrderLine> SalesOrderLines { get; set; } = [];

    public virtual ICollection<SalesShipmentLine> SalesShipmentLines { get; set; } = [];
}
