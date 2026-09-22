using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class SalesInvoiceLine : BaseEntity
{
    public int SalesInvoiceLineId { get; set; }

    public int SalesInvoiceId { get; set; }

    public int? SalesOrderLineId { get; set; }

    public int? ItemId { get; set; }

    public string Description { get; set; } = null!;

    public decimal Quantity { get; set; }

    public int UomId { get; set; }

    public decimal UnitPrice { get; set; }

    public int? TaxCodeId { get; set; }

    public decimal LineAmount { get; set; }

    public decimal LineTaxAmount { get; set; }

    public virtual Item? Item { get; set; }

    public virtual SalesInvoiceHeader SalesInvoice { get; set; } = null!;

    public virtual SalesOrderLine? SalesOrderLine { get; set; }

    public virtual TaxCode? TaxCode { get; set; }

    public virtual UnitOfMeasure Uom { get; set; } = null!;
}
