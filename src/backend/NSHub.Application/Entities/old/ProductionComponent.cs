using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class ProductionComponent : BaseEntity
{

    public Guid ProductionPhaseId { get; set; }

    public Guid ArticleId { get; set; }

    public Guid WarehouseId { get; set; }

    public decimal Quantity { get; set; }

    public decimal Price { get; set; }

    public bool FixedPrice { get; set; }

    public decimal Amount { get; set; }

    public Guid SupplyingBodyId { get; set; }


    public virtual Warehouse? Warehouse { get; set; }
    public virtual Article? Article { get; set; }
    public virtual ProductionPhase? ProductionPhase { get; set; }
    public virtual SupplyingBody? SupplyingBody { get; set; }

}
