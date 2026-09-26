// <copyright file="DeliveryNoteRow.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a delivery note row.
/// </summary>
public class DeliveryNoteRow : AuditableTenantEntity
{
    /// <summary>
    /// Gets the delivery note year.
    /// </summary>
    public int Year { get; protected set; }

    /// <summary>
    /// Gets the delivery note identifier.
    /// </summary>
    public Guid DeliveryNoteId { get; protected set; }

    /// <summary>
    /// Gets the related order row identifier.
    /// </summary>
    public Guid? OrderRowId { get; protected set; }

    /// <summary>
    /// Gets the article identifier.
    /// </summary>
    public Guid? ArticleId { get; protected set; }

    /// <summary>
    /// Gets the article code.
    /// </summary>
    public string? ArticleCode { get; protected set; }

    /// <summary>
    /// Gets the delivered quantity.
    /// </summary>
    public decimal? Quantity { get; protected set; }

    /// <summary>
    /// Gets the unit price.
    /// </summary>
    public decimal? UnitPrice { get; protected set; }

    /// <summary>
    /// Gets the row description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the unit of measure code.
    /// </summary>
    public string UnitOfMeasureCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the row number.
    /// </summary>
    public decimal? RowNumber { get; protected set; }

    /// <summary>
    /// Gets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; protected set; }

    /// <summary>
    /// Gets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; protected set; }

    /// <summary>
    /// Gets the associated delivery note.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual DeliveryNote? DeliveryNote { get; protected set; }

    /// <summary>
    /// Gets the associated order row.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual OrderRow? OrderRow { get; protected set; }

    /// <summary>
    /// Gets the stock movements generated from this delivery note row.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<StockMovement> StockMovements { get; protected set; }
        = new List<StockMovement>();
}
