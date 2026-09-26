using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class ShipmentArticle : AuditableTenantEntity
{
    public string? Notes { get; protected set; }
    public decimal Quantity { get; protected set; }
    public bool IsWarranty { get; protected set; }
    public Guid ShipmentId { get; protected set; }
    public Guid? ArticleId { get; protected set; }
    public virtual Article? Article { get; protected set; }
    public virtual Shipment? Shipment { get; protected set; }

    protected ShipmentArticle() { }

    public static ShipmentArticle Create()
    {
        return new ShipmentArticle();
    }
}
