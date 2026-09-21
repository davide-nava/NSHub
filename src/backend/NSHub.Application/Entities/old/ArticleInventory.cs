using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ArticleInventory : BaseEntity
{
    public Guid ArticleId { get; set; }

    public Guid WarehouseId { get; set; }

    public decimal Stock { get; set; }

    public decimal Availability { get; set; }

    public decimal Charge { get; set; }

    public decimal Discharge { get; set; }

    public decimal Incoming { get; set; }

    public decimal Outgoing { get; set; }

    public virtual Article? Article { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
