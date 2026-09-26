using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class OrderRow : AuditableTenantEntity
{
    public Guid OrderId { get; protected set; }
    public int RowNumber { get; protected set; }
    public Guid? ArticleId { get; protected set; }
    public string? ArticleCode { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public decimal Quantity { get; protected set; }
    public decimal DeliveredQuantity { get; protected set; }
    public decimal InvoicedQuantity { get; protected set; }
    public decimal UnitPrice { get; protected set; }
    public decimal DiscountPercentage { get; protected set; }
    public decimal LineTotal { get; protected set; }
    public Guid? VatId { get; protected set; }
    public Guid? WarehouseId { get; protected set; }
    public DateTime? ExpectedDeliveryDate { get; protected set; }
    public virtual Article? Article { get; protected set; }
    public virtual Order? Order { get; protected set; }
    public virtual Vat? Vat { get; protected set; }
    public virtual Warehouse? Warehouse { get; protected set; }

    private readonly List<DeliveryNoteRow> _deliveryNoteRows = new();
    public virtual IReadOnlyCollection<DeliveryNoteRow> DeliveryNoteRows => _deliveryNoteRows.AsReadOnly();
    private readonly List<StockMovement> _stockMovements = new();
    public virtual IReadOnlyCollection<StockMovement> StockMovements => _stockMovements.AsReadOnly();

    protected OrderRow() { }

    public static OrderRow Create()
    {
        return new OrderRow();
    }
}
