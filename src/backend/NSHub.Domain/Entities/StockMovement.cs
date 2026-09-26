using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class StockMovement : AuditableTenantEntity
{
    public DateTime MovementDate { get; protected set; }
    public string MovementType { get; protected set; } = string.Empty;
    public Guid ArticleId { get; protected set; }
    public Guid WarehouseId { get; protected set; }
    public Guid? TargetWarehouseId { get; protected set; }
    public decimal Quantity { get; protected set; }
    public decimal? UnitCost { get; protected set; }
    public Guid? DeliveryNoteRowId { get; protected set; }
    public Guid? InvoiceRowId { get; protected set; }
    public Guid? OrderRowId { get; protected set; }
    public string? BatchNumber { get; protected set; }
    public string? SerialCode { get; protected set; }
    public string? Notes { get; protected set; }
    public virtual Article? Article { get; protected set; }
    public virtual DeliveryNoteRow? DeliveryNoteRow { get; protected set; }
    public virtual OrderRow? OrderRow { get; protected set; }
    public virtual Warehouse? TargetWarehouse { get; protected set; }
    public virtual Warehouse? Warehouse { get; protected set; }

    protected StockMovement() { }

    public static StockMovement Create()
    {
        return new StockMovement();
    }
}
