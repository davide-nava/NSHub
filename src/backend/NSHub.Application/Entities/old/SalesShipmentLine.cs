using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class SalesShipmentLine : BaseEntity
{
    public int SalesShipmentLineId { get; set; }

    public int SalesShipmentId { get; set; }

    public int? SalesOrderLineId { get; set; }

    public int ItemId { get; set; }

    public decimal ShippedQuantity { get; set; }

    public int UomId { get; set; }

    public virtual Item Item { get; set; } = null!;

    public virtual SalesOrderLine? SalesOrderLine { get; set; }

    public virtual SalesShipmentHeader SalesShipment { get; set; } = null!;

    public virtual UnitOfMeasure Uom { get; set; } = null!;
}
