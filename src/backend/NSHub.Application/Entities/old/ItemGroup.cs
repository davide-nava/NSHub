using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class ItemGroup : BaseEntity
{
    public int ItemGroupId { get; set; }

    public int CompanyId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int? RevenueAccountId { get; set; }

    public int? CostAccountId { get; set; }

    public int? InventoryAccountId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual GlAccount? CostAccount { get; set; }

    public virtual GlAccount? InventoryAccount { get; set; }

    public virtual ICollection<Item> Items { get; set; } = [];

    public virtual GlAccount? RevenueAccount { get; set; }
}
