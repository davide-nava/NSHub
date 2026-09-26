// <copyright file="DeliveryNote.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class DeliveryNote : AuditableTenantEntity
{
    public string DeliveryNoteNumber { get; protected set; } = string.Empty;
    public int Year { get; protected set; }
    public DateTime? Date { get; protected set; }
    public Guid? OrderId { get; protected set; }
    public Guid? InvoiceCustomerId { get; protected set; }
    public Guid? GoodsCustomerId { get; protected set; }
    public Guid? ShippingAddressId { get; protected set; }
    public string TransportReasonCode { get; protected set; } = string.Empty;
    public string GoodsAppearanceCode { get; protected set; } = string.Empty;
    public string TransportCareCode { get; protected set; } = string.Empty;
    public string CarriageCode { get; protected set; } = string.Empty;
    public string? Notes { get; protected set; }
    public decimal? PackageCount { get; protected set; }
    public decimal? Weight { get; protected set; }
    public DateTime? InsertionDate { get; protected set; }
    public string? Carriers { get; protected set; }
    public bool? IsClosed { get; protected set; }
    public string? OurReference { get; protected set; }
    public string? OrderReference { get; protected set; }
    public string? TheirReference { get; protected set; }
    public virtual Customer? GoodsCustomer { get; protected set; }
    public virtual Customer? InvoiceCustomer { get; protected set; }
    public virtual Order? Order { get; protected set; }

    private readonly List<DeliveryNoteRow> _deliveryNoteRows = new();
    public virtual IReadOnlyCollection<DeliveryNoteRow> DeliveryNoteRows => _deliveryNoteRows.AsReadOnly();

    protected DeliveryNote() { }

    public static DeliveryNote Create()
    {
        return new DeliveryNote();
    }
}
