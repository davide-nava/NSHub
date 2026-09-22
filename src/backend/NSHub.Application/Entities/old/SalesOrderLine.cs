using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class SalesOrderLine : BaseEntity
{
    public int SalesOrderLineId { get; set; }

    public int SalesOrderId { get; set; }

    public int LineNumber { get; set; }

    public int ItemId { get; set; }

    public string Description { get; set; } = null!;

    public decimal OrderedQuantity { get; set; }

    public int UomId { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal DiscountPercent { get; set; }

    public int? TaxCodeId { get; set; }

    public int WarehouseId { get; set; }

    public decimal LineAmount { get; set; }

    public decimal LineTaxAmount { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual ICollection<SalesInvoiceLine> SalesInvoiceLines { get; set; } = [];

    public virtual SalesOrderHeader SalesOrder { get; set; } = null!;

    public virtual ICollection<SalesShipmentLine> SalesShipmentLines { get; set; } = [];

    public virtual TaxCode? TaxCode { get; set; }

    public virtual UnitOfMeasure Uom { get; set; } = null!;

    public virtual Warehouse Warehouse { get; set; } = null!;
}
