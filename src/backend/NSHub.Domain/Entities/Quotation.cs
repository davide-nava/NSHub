// <copyright file="Quotation.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Quotation : AuditableTenantEntity
{
    public string QuotationNumber { get; protected set; } = string.Empty;
    public int Year { get; protected set; }
    public DateTime? Date { get; protected set; }
    public Guid? CustomerId { get; protected set; }
    public decimal? Amount { get; protected set; }
    public decimal? Quantity { get; protected set; }
    public DateTime? InsertionDate { get; protected set; }
    public string? Notes { get; protected set; }
    public bool? IsClosed { get; protected set; }
    public Guid? VatId { get; protected set; }
    public Guid PaymentId { get; protected set; }
    public bool IsSale { get; protected set; }
    public string? OurReference { get; protected set; }
    public string? TheirReference { get; protected set; }
    public int ValidityDays { get; protected set; }
    public decimal TotalNetAmount { get; protected set; }
    public decimal TotalGrossAmount { get; protected set; }
    public string StatusCode { get; protected set; } = string.Empty;
    public virtual Customer? Customer { get; protected set; }
    public virtual Payment? Payment { get; protected set; }
    public virtual Vat? Vat { get; protected set; }

    private readonly List<Order> _orders = new();
    public virtual IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
    private readonly List<QuotationRow> _quotationRows = new();
    public virtual IReadOnlyCollection<QuotationRow> QuotationRows => _quotationRows.AsReadOnly();

    protected Quotation() { }

    public static Quotation Create()
    {
        return new Quotation();
    }
}
