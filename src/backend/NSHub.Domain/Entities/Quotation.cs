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
    /// Gets or sets the quotation number.
    /// </summary>
    public string QuotationNumber { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the quotation year.
    /// </summary>
    public int Year { get; set; }

    /// <summary>
    /// Gets or sets the quotation date.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Gets or sets the customer identifier.
    /// </summary>
    public Guid? CustomerId { get; set; }

    /// <summary>
    /// Gets or sets the quotation amount.
    /// </summary>
    public decimal? Amount { get; set; }

    /// <summary>
    /// Gets or sets the total quantity.
    /// </summary>
    public decimal? Quantity { get; set; }

    /// <summary>
    /// Gets or sets the insertion date.
    /// </summary>
    public DateTime? InsertionDate { get; set; }

    /// <summary>
    /// Gets or sets additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the quotation is closed.
    /// </summary>
    public bool? IsClosed { get; set; }

    /// <summary>
    /// Gets or sets the VAT identifier.
    /// </summary>
    public Guid? VatId { get; set; }

    /// <summary>
    /// Gets or sets the payment method identifier.
    /// </summary>
    public Guid PaymentId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is a sales quotation.
    /// </summary>
    public bool IsSale { get; set; }

    /// <summary>
    /// Gets or sets our reference.
    /// </summary>
    public string? OurReference { get; set; }

    /// <summary>
    /// Gets or sets the customer's reference.
    /// </summary>
    public string? TheirReference { get; set; }

    /// <summary>
    /// Gets or sets the validity period in days.
    /// </summary>
    public int ValidityDays { get; set; }

    /// <summary>
    /// Gets or sets the total net amount.
    /// </summary>
    public decimal TotalNetAmount { get; set; }

    /// <summary>
    /// Gets or sets the total gross amount.
    /// </summary>
    public decimal TotalGrossAmount { get; set; }

    /// <summary>
    /// Gets or sets the quotation status code.
    /// </summary>
    public string StatusCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the associated customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Customer? Customer { get; set; }

    /// <summary>
    /// Gets or sets the associated payment method.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Payment? Payment { get; set; }

    /// <summary>
    /// Gets or sets the associated VAT rate.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Vat? Vat { get; set; }

    /// <summary>
    /// Gets or sets the rows associated with this quotation.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<QuotationRow> QuotationRows { get; set; }
        = [];
}
