using System;

namespace PlanetHub.ApplicationCore.Entities;

public class WarehouseOnWarehouseAccount : BaseEntity
{
    public Guid WarehouseAccountId { get; set; }

    public Guid WarehouseId { get; set; }

    public Guid TransactionTypeId { get; set; }

    public virtual TransactionType? TransactionType { get; set; }

    public bool IsSign { get; set; }

    public bool CanAddTransaction { get; set; }

    public Guid PriorityTypeId { get; set; }

    public virtual PriorityType? PriorityType { get; set; }

    public virtual WarehouseAccount? WarehouseAccount { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
