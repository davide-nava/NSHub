// <copyright file="Customer.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a customer.
/// </summary>
public class Customer : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the customer code.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the company name.
    /// </summary>
    public string CompanyName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the VAT number.
    /// </summary>
    public string? VatNumber { get; set; }

    /// <summary>
    /// Gets or sets the tax code.
    /// </summary>
    public string? TaxCode { get; set; }

    /// <summary>
    /// Gets or sets the SDI code.
    /// </summary>
    public string? SdiCode { get; set; }

    /// <summary>
    /// Gets or sets the PEC email address.
    /// </summary>
    public string? PecEmail { get; set; }

    /// <summary>
    /// Gets or sets the email address.
    /// </summary>
    public string? Email { get; set; }

    /// <summary>
    /// Gets or sets the phone number.
    /// </summary>
    public string? Phone { get; set; }

    /// <summary>
    /// Gets or sets the website URL.
    /// </summary>
    public string? Website { get; set; }

    /// <summary>
    /// Gets or sets the legal address identifier.
    /// </summary>
    public Guid? LegalAddressId { get; set; }

    /// <summary>
    /// Gets or sets the shipping address identifier.
    /// </summary>
    public Guid? ShippingAddressId { get; set; }

    /// <summary>
    /// Gets or sets the payment term identifier.
    /// </summary>
    public Guid? PaymentId { get; set; }

    /// <summary>
    /// Gets or sets the default VAT identifier.
    /// </summary>
    public Guid? VatId { get; set; }

    /// <summary>
    /// Gets or sets the bank account identifier.
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// Gets or sets the customer credit limit.
    /// </summary>
    public decimal? CreditLimit { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the customer is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the associated bank account.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual BankAccount? BankAccount { get; set; }

    /// <summary>
    /// Gets or sets the associated payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Payment? Payment { get; set; }

    /// <summary>
    /// Gets or sets the associated VAT rate.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Vat? Vat { get; set; }

    /// <summary>
    /// Gets or sets the legal address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? LegalAddress { get; set; }

    /// <summary>
    /// Gets or sets the shipping address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? ShippingAddress { get; set; }

    /// <summary>
    /// Gets or sets the quotations associated with this customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Quotation> Quotations { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the orders associated with this customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Order> Orders { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the shipments associated with this customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Shipment> Shipments { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the tickets associated with this customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Ticket> Tickets { get; set; }
        = [];
}
