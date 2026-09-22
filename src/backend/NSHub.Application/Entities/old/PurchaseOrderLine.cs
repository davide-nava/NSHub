using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class PurchaseOrderLine : BaseEntity
{
    public int PurchaseOrderLineId { get; set; }

    public int PurchaseOrderId { get; set; }

    public int LineNumber { get; set; }

    public int ItemId { get; set; }

    public string Description { get; set; } = null!;

    public decimal OrderedQuantity { get; set; }

    public int UomId { get; set; }

    public decimal UnitPrice { get; set; }

    public int? TaxCodeId { get; set; }

    public int WarehouseId { get; set; }

    public decimal LineAmount { get; set; }

    public decimal LineTaxAmount { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual ICollection<PurchaseInvoiceLine> PurchaseInvoiceLines { get; set; } = [];

    public virtual PurchaseOrderHeader PurchaseOrder { get; set; } = null!;

    public virtual ICollection<PurchaseReceiptLine> PurchaseReceiptLines { get; set; } = [];

    public virtual TaxCode? TaxCode { get; set; }

    public virtual UnitOfMeasure Uom { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
