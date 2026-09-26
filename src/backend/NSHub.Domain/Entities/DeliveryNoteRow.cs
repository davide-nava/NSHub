// <copyright file="DeliveryNoteRow.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class DeliveryNoteRow : AuditableTenantEntity
{
    public int Year { get; protected set; }
    public Guid DeliveryNoteId { get; protected set; }
    public Guid? OrderRowId { get; protected set; }
    public Guid? ArticleId { get; protected set; }
    public string? ArticleCode { get; protected set; }
    public decimal? Quantity { get; protected set; }
    public decimal? UnitPrice { get; protected set; }
    public string Description { get; protected set; } = string.Empty;
    public string UnitOfMeasureCode { get; protected set; } = string.Empty;
    public decimal? RowNumber { get; protected set; }
    public DateTime? InsertionDate { get; protected set; }
    public virtual Article? Article { get; protected set; }
    public virtual DeliveryNote? DeliveryNote { get; protected set; }
    public virtual OrderRow? OrderRow { get; protected set; }

    private readonly List<StockMovement> _stockMovements = new();
    public virtual IReadOnlyCollection<StockMovement> StockMovements => _stockMovements.AsReadOnly();

    protected DeliveryNoteRow() { }

    public static DeliveryNoteRow Create()
    {
        return new DeliveryNoteRow();
    }
}
