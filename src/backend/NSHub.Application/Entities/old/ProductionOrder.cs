using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class ProductionOrder : BaseEntity
{
    public Guid ParentId { get; set; }

    public Guid ArticleId { get; set; }

    public Guid WarehouseId { get; set; }

    public DateTime DateOrder { get; set; }

    public DateTime DateEndOrder { get; set; }

    public DateTime DateCalculatedEndOrder { get; set; }

    public StatusType StatusType { get; set; }

    public ProductionOrderType ProductionOrderType { get; set; }

    public decimal Value { get; set; }

    public decimal Quantity { get; set; }

    public string Code { get; set; } = null!;

    public string ProductionPriceType { get; set; } = null!;

    public string ComponentPriceType { get; set; } = null!;

    public decimal Amount { get; set; }

    public Guid DocumentBodyId { get; set; }

    public Guid JobEntryId { get; set; }

    public bool FixedPrice { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual ProductionOrder? ProductionOrderParent { get; set; }
    public virtual Article? Article { get; set; }
    public virtual Warehouse? Warehouse { get; set; }
    public virtual DocumentBody? DocumentBody { get; set; }
    public virtual JobEntry? JobEntry { get; set; }

}
