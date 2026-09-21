using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class SalesShipmentHeader : BaseEntity
{
    public int SalesShipmentId { get; set; }

    public int CompanyId { get; set; }

    public string ShipmentNumber { get; set; } = null!;

    public DateOnly ShipmentDate { get; set; }

    public int CustomerId { get; set; }

    public int WarehouseId { get; set; }

    public string Status { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual ICollection<SalesShipmentLine> SalesShipmentLines { get; set; } = [];

    public virtual Warehouse Warehouse { get; set; } = null!;
}
