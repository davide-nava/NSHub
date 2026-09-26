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
    /// Gets the movement date.
    /// </summary>
    public DateTime MovementDate { get; protected set; }

    /// <summary>
    /// Gets the movement type.
    /// </summary>
    public string MovementType { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the article identifier.
    /// </summary>
    public Guid ArticleId { get; protected set; }

    /// <summary>
    /// Gets the source warehouse identifier.
    /// </summary>
    public Guid WarehouseId { get; protected set; }

    /// <summary>
    /// Gets the target warehouse identifier.
    /// </summary>
    public Guid? TargetWarehouseId { get; protected set; }

    /// <summary>
    /// Gets the movement quantity.
    /// </summary>
    public decimal Quantity { get; protected set; }

    /// <summary>
    /// Gets the unit cost associated with the movement.
    /// </summary>
    public decimal? UnitCost { get; protected set; }

    /// <summary>
    /// Gets the related delivery note row identifier.
    /// </summary>
    public Guid? DeliveryNoteRowId { get; protected set; }

    /// <summary>
    /// Gets the related invoice row identifier.
    /// </summary>
    public Guid? InvoiceRowId { get; protected set; }

    /// <summary>
    /// Gets the related order row identifier.
    /// </summary>
    public Guid? OrderRowId { get; protected set; }

    /// <summary>
    /// Gets the batch number.
    /// </summary>
    public string? BatchNumber { get; protected set; }

    /// <summary>
    /// Gets the serial code.
    /// </summary>
    public string? SerialCode { get; protected set; }

    /// <summary>
    /// Gets the movement notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; protected set; }

    /// <summary>
    /// Gets the associated delivery note row.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual DeliveryNoteRow? DeliveryNoteRow { get; protected set; }

    /// <summary>
    /// Gets the associated order row.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual OrderRow? OrderRow { get; protected set; }

    /// <summary>
    /// Gets the target warehouse.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Warehouse? TargetWarehouse { get; protected set; }

    /// <summary>
    /// Gets the source warehouse.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Warehouse? Warehouse { get; protected set; }
}
