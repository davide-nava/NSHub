using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PurchaseInvoiceLine : BaseEntity
{
    public int PurchaseInvoiceLineId { get; set; }

    public int PurchaseInvoiceId { get; set; }

    public int? PurchaseOrderLineId { get; set; }

    public int? ItemId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Quantity { get; set; }

    public int UomId { get; set; }

    public decimal UnitPrice { get; set; }

    public int? TaxCodeId { get; set; }

    public decimal LineAmount { get; set; }

    public decimal LineTaxAmount { get; set; }

    public virtual Item? Item { get; set; }

    public virtual PurchaseInvoiceHeader PurchaseInvoice { get; set; } = null!;

    public virtual PurchaseOrderLine? PurchaseOrderLine { get; set; }

    public virtual TaxCode? TaxCode { get; set; }

    public virtual UnitOfMeasure Uom { get; set; } = null!;
}
