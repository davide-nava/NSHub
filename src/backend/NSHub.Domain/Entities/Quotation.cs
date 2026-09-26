// <copyright file="Quotation.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a quotation.
/// </summary>
public class Quotation : AuditableTenantEntity
{
    /// <summary>
    /// Gets the quotation number.
    /// </summary>
    public string QuotationNumber { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the quotation year.
    /// </summary>
    public int Year { get; protected set; }

    /// <summary>
    /// Gets the quotation date.
    /// </summary>
    public DateTime? Date { get; protected set; }

    /// <summary>
    /// Gets the customer identifier.
    /// </summary>
    public Guid? CustomerId { get; protected set; }

    /// <summary>
    /// Gets the quotation amount.
    /// </summary>
    public decimal? Amount { get; protected set; }

    /// <summary>
    /// Gets the total quantity.
    /// </summary>
    public decimal? Quantity { get; protected set; }

    /// <summary>
    /// Gets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; protected set; }

    /// <summary>
    /// Gets additional notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the quotation is closed.
    /// </summary>
    public bool? IsClosed { get; protected set; }

    /// <summary>
    /// Gets the VAT identifier.
    /// </summary>
    public Guid? VatId { get; protected set; }

    /// <summary>
    /// Gets the payment method identifier.
    /// </summary>
    public Guid PaymentId { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether this is a sales quotation.
    /// </summary>
    public bool IsSale { get; protected set; }

    /// <summary>
    /// Gets our reference.
    /// </summary>
    public string? OurReference { get; protected set; }

    /// <summary>
    /// Gets the customer's reference.
    /// </summary>
    public string? TheirReference { get; protected set; }

    /// <summary>
    /// Gets the validity period in days.
    /// </summary>
    public int ValidityDays { get; protected set; }

    /// <summary>
    /// Gets the total net amount.
    /// </summary>
    public decimal TotalNetAmount { get; protected set; }

    /// <summary>
    /// Gets the total gross amount.
    /// </summary>
    public decimal TotalGrossAmount { get; protected set; }

    /// <summary>
    /// Gets the quotation status code.
    /// </summary>
    public string StatusCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; protected set; }

    /// <summary>
    /// Gets the associated payment method.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Payment? Payment { get; protected set; }

    /// <summary>
    /// Gets the associated VAT rate.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Vat? Vat { get; protected set; }

    /// <summary>
    /// Gets the rows associated with this quotation.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<QuotationRow> QuotationRows { get; protected set; }
        = new List<QuotationRow>();
}
