// <copyright file="UnitOfMeasure.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class UnitOfMeasure : BaseEntityType
{

    public virtual ICollection<ItemUomConversion> ItemUomConversionFromUoms { get; set; } = [];

    public virtual ICollection<ItemUomConversion> ItemUomConversionToUoms { get; set; } = [];

    public virtual ICollection<Item> Items { get; set; } = [];

    public virtual ICollection<PurchaseInvoiceLine> PurchaseInvoiceLines { get; set; } = [];
    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = [];

    public virtual ICollection<PurchaseReceiptLine> PurchaseReceiptLines { get; set; } = [];

    public virtual ICollection<SalesInvoiceLine> SalesInvoiceLines { get; set; } = [];
    public virtual ICollection<SalesOrderLine> SalesOrderLines { get; set; } = [];

    public virtual ICollection<SalesShipmentLine> SalesShipmentLines { get; set; } = [];

}
