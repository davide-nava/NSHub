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
    /// Gets the delivery note number.
    /// </summary>
    public string DeliveryNoteNumber { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the delivery note year.
    /// </summary>
    public int Year { get; protected set; }

    /// <summary>
    /// Gets the delivery note date.
    /// </summary>
    public DateTime? Date { get; protected set; }

    /// <summary>
    /// Gets the related order identifier.
    /// </summary>
    public Guid? OrderId { get; protected set; }

    /// <summary>
    /// Gets the invoice customer identifier.
    /// </summary>
    public Guid? InvoiceCustomerId { get; protected set; }

    /// <summary>
    /// Gets the goods recipient customer identifier.
    /// </summary>
    public Guid? GoodsCustomerId { get; protected set; }

    /// <summary>
    /// Gets the shipping address identifier.
    /// </summary>
    public Guid? ShippingAddressId { get; protected set; }

    /// <summary>
    /// Gets the transport reason code.
    /// </summary>
    public string TransportReasonCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the goods appearance code.
    /// </summary>
    public string GoodsAppearanceCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the transport carrier code.
    /// </summary>
    public string TransportCareCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the carriage code.
    /// </summary>
    public string CarriageCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets additional notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the package count.
    /// </summary>
    public decimal? PackageCount { get; protected set; }

    /// <summary>
    /// Gets the total weight.
    /// </summary>
    public decimal? Weight { get; protected set; }

    /// <summary>
    /// Gets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; protected set; }

    /// <summary>
    /// Gets carrier information.
    /// </summary>
    public string? Carriers { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the delivery note is closed.
    /// </summary>
    public bool? IsClosed { get; protected set; }

    /// <summary>
    /// Gets our reference.
    /// </summary>
    public string? OurReference { get; protected set; }

    /// <summary>
    /// Gets the order reference.
    /// </summary>
    public string? OrderReference { get; protected set; }

    /// <summary>
    /// Gets the customer reference.
    /// </summary>
    public string? TheirReference { get; protected set; }

    /// <summary>
    /// Gets the customer to be invoiced.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? InvoiceCustomer { get; protected set; }

    /// <summary>
    /// Gets the customer receiving the goods.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? GoodsCustomer { get; protected set; }

    /// <summary>
    /// Gets the associated order.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Order? Order { get; protected set; }

    /// <summary>
    /// Gets the delivery note rows.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<DeliveryNoteRow> DeliveryNoteRows { get; protected set; }
        = new List<DeliveryNoteRow>();
}
