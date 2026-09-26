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
    /// Gets or sets the delivery note year.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the delivery note identifier.
    /// </summary>
    public Guid DeliveryNoteId { get; set; }

    /// <summary>
    /// Gets or sets the related order row identifier.
    /// </summary>
    public Guid? OrderRowId { get; set; }

    /// <summary>
    /// Gets or sets the article identifier.
    /// </summary>
    public Guid? ArticleId { get; set; }

    /// <summary>
    /// Gets or sets the article code.
    /// </summary>
    public string? ArticleCode { get; set; }

    /// <summary>
    /// Gets or sets the delivered quantity.
    /// </summary>
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Gets or sets the unit price.
    /// </summary>
    public decimal? UnitPrice { get; set; }

    /// <summary>
    /// Gets or sets the row description.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the unit of measure code.
    /// </summary>
    public string UnitOfMeasureCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the row number.
    /// </summary>
    public decimal? RowNumber { get; set; }

    /// <summary>
    /// Gets or sets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; set; }

    /// <summary>
    /// Gets or sets the associated article.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Article? Article { get; set; }

    /// <summary>
    /// Gets or sets the associated delivery note.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual DeliveryNote? DeliveryNote { get; set; }

    /// <summary>
    /// Gets or sets the associated order row.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual OrderRow? OrderRow { get; set; }

    /// <summary>
    /// Gets or sets the stock movements generated from this delivery note row.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<StockMovement> StockMovements { get; set; }
        = [];
}
