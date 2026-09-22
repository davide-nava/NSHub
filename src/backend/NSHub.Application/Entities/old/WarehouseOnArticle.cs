using System;

namespace NSHub.ApplicationCore.Entities;

public class WarehouseOnArticle : BaseEntity
{
    public Guid ArticleId { get; set; }

    public Guid WarehouseId { get; set; }

    public string Position { get; set; } = null!;

    public bool IsDefaultWarehouse { get; set; }

    public decimal MinimumStock { get; set; }

    public virtual Article? Article { get; set; }

    public virtual Warehouse? Warehouse { get; set; }
}
