using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Presentation;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ArticleHandling : BaseEntity
{
    public Guid ArticleId { get; set; }

    public Guid WarehouseId { get; set; }

    public TransactionType TransactionType { get; set; }

    public DateTime HandlingDate { get; set; }

    public decimal Quantity { get; set; }

    public decimal Amount { get; set; }

    public Guid OriginId { get; set; }

    public OriginType OriginType { get; set; }
    public DateTime DateEndHandling { get; set; }

    public Guid WarehouseOnWarehouseAccountId { get; set; }

    public DateTime ReversedDate { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual WarehouseOnWarehouseAccount? WarehouseOnWarehouseAccount { get; set; }
    public virtual Origin? Origin { get; set; }

    public virtual Article? Article { get; set; }

    public virtual Warehouse? Warehouse { get; set; }

}
