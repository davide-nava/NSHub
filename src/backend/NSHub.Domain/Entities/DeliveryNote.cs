// <copyright file="DeliveryNote.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a delivery note.
/// </summary>
public class DeliveryNote : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the delivery note number.
    /// </summary>
    public string DeliveryNoteNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the delivery note year.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the delivery note date.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Gets or sets the related order identifier.
    /// </summary>
    public Guid? OrderId { get; set; }

    /// <summary>
    /// Gets or sets the invoice customer identifier.
    /// </summary>
    public Guid? InvoiceCustomerId { get; set; }

    /// <summary>
    /// Gets or sets the goods recipient customer identifier.
    /// </summary>
    public Guid? GoodsCustomerId { get; set; }

    /// <summary>
    /// Gets or sets the shipping address identifier.
    /// </summary>
    public Guid? ShippingAddressId { get; set; }

    /// <summary>
    /// Gets or sets the transport reason code.
    /// </summary>
    public string TransportReasonCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the goods appearance code.
    /// </summary>
    public string GoodsAppearanceCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the transport carrier code.
    /// </summary>
    public string TransportCareCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the carriage code.
    /// </summary>
    public string CarriageCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the package count.
    /// </summary>
    public decimal? PackageCount { get; set; }

    /// <summary>
    /// Gets or sets the total weight.
    /// </summary>
    public decimal? Weight { get; set; }

    /// <summary>
    /// Gets or sets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; set; }

    /// <summary>
    /// Gets or sets carrier information.
    /// </summary>
    public string? Carriers { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the delivery note is closed.
    /// </summary>
    public bool? IsClosed { get; set; }

    /// <summary>
    /// Gets or sets our reference.
    /// </summary>
    public string? OurReference { get; set; }

    /// <summary>
    /// Gets or sets the order reference.
    /// </summary>
    public string? OrderReference { get; set; }

    /// <summary>
    /// Gets or sets the customer reference.
    /// </summary>
    public string? TheirReference { get; set; }

    /// <summary>
    /// Gets or sets the customer to be invoiced.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? InvoiceCustomer { get; set; }

    /// <summary>
    /// Gets or sets the customer receiving the goods.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? GoodsCustomer { get; set; }

    /// <summary>
    /// Gets or sets the associated order.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Order? Order { get; set; }

    /// <summary>
    /// Gets or sets the delivery note rows.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<DeliveryNoteRow> DeliveryNoteRows { get; set; }
        = [];
}
