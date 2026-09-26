// <copyright file="StockMovement.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a stock movement.
/// </summary>
public class StockMovement : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the movement date.
    /// </summary>
    public DateTime MovementDate { get; set; }

    /// <summary>
    /// Gets or sets the movement type.
    /// </summary>
    public string MovementType { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the article identifier.
    /// </summary>
    public Guid ArticleId { get; set; }

    /// <summary>
    /// Gets or sets the source warehouse identifier.
    /// </summary>
    public Guid WarehouseId { get; set; }

    /// <summary>
    /// Gets or sets the target warehouse identifier.
    /// </summary>
    public Guid? TargetWarehouseId { get; set; }

    /// <summary>
    /// Gets or sets the movement quantity.
    /// </summary>
    public decimal Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit cost associated with the movement.
    /// </summary>
    public decimal? UnitCost { get; set; }

    /// <summary>
    /// Gets or sets the related delivery note row identifier.
    /// </summary>
    public Guid? DeliveryNoteRowId { get; set; }

    /// <summary>
    /// Gets or sets the related invoice row identifier.
    /// </summary>
    public Guid? InvoiceRowId { get; set; }

    /// <summary>
    /// Gets or sets the related order row identifier.
    /// </summary>
    public Guid? OrderRowId { get; set; }

    /// <summary>
    /// Gets or sets the batch number.
    /// </summary>
    public string? BatchNumber { get; set; }

    /// <summary>
    /// Gets or sets the serial code.
    /// </summary>
    public string? SerialCode { get; set; }

    /// <summary>
    /// Gets or sets the movement notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; set; }

    /// <summary>
    /// Gets or sets the associated delivery note row.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual DeliveryNoteRow? DeliveryNoteRow { get; set; }

    /// <summary>
    /// Gets or sets the associated order row.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual OrderRow? OrderRow { get; set; }

    /// <summary>
    /// Gets or sets the target warehouse.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Warehouse? TargetWarehouse { get; set; }

    /// <summary>
    /// Gets or sets the source warehouse.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Warehouse? Warehouse { get; set; }
}
