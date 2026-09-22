using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class Warehouse : BaseEntity
{
    public Guid CompanyId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public Guid? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<InventoryBalance> InventoryBalances { get; set; } = [];

    public virtual ICollection<InventoryTransaction> InventoryTransactions { get; set; } = [];

    public virtual ICollection<Location> Locations { get; set; } = [];

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = [];
    public virtual ICollection<PurchaseReceiptHeader> PurchaseReceiptHeaders { get; set; } = [];

    public virtual ICollection<SalesOrderLine> SalesOrderLines { get; set; } = [];

    public virtual ICollection<SalesShipmentHeader> SalesShipmentHeaders { get; set; } = [];
}
