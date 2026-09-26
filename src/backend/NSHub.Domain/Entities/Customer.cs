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
    /// Gets the customer code.
    /// </summary>
    public string Code { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the company name.
    /// </summary>
    public string CompanyName { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the VAT number.
    /// </summary>
    public string? VatNumber { get; protected set; }

    /// <summary>
    /// Gets the tax code.
    /// </summary>
    public string? TaxCode { get; protected set; }

    /// <summary>
    /// Gets the SDI code.
    /// </summary>
    public string? SdiCode { get; protected set; }

    /// <summary>
    /// Gets the PEC email address.
    /// </summary>
    public string? PecEmail { get; protected set; }

    /// <summary>
    /// Gets the email address.
    /// </summary>
    public string? Email { get; protected set; }

    /// <summary>
    /// Gets the phone number.
    /// </summary>
    public string? Phone { get; protected set; }

    /// <summary>
    /// Gets the website URL.
    /// </summary>
    public string? Website { get; protected set; }

    /// <summary>
    /// Gets the legal address identifier.
    /// </summary>
    public Guid? LegalAddressId { get; protected set; }

    /// <summary>
    /// Gets the shipping address identifier.
    /// </summary>
    public Guid? ShippingAddressId { get; protected set; }

    /// <summary>
    /// Gets the payment term identifier.
    /// </summary>
    public Guid? PaymentId { get; protected set; }

    /// <summary>
    /// Gets the default VAT identifier.
    /// </summary>
    public Guid? VatId { get; protected set; }

    /// <summary>
    /// Gets the bank account identifier.
    /// </summary>
    public Guid? BankAccountId { get; protected set; }

    /// <summary>
    /// Gets the customer credit limit.
    /// </summary>
    public decimal? CreditLimit { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the customer is active.
    /// </summary>
    public bool IsActive { get; protected set; }

    /// <summary>
    /// Gets additional notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the associated bank account.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual BankAccount? BankAccount { get; protected set; }

    /// <summary>
    /// Gets the associated payment term.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Payment? Payment { get; protected set; }

    /// <summary>
    /// Gets the associated VAT rate.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Vat? Vat { get; protected set; }

    /// <summary>
    /// Gets the legal address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? LegalAddress { get; protected set; }

    /// <summary>
    /// Gets the shipping address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? ShippingAddress { get; protected set; }

    /// <summary>
    /// Gets the quotations associated with this customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Quotation> Quotations { get; protected set; }
        = new List<Quotation>();

    /// <summary>
    /// Gets the orders associated with this customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Order> Orders { get; protected set; }
        = new List<Order>();

    /// <summary>
    /// Gets the shipments associated with this customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Shipment> Shipments { get; protected set; }
        = new List<Shipment>();

    /// <summary>
    /// Gets the tickets associated with this customer.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Ticket> Tickets { get; protected set; }
        = new List<Ticket>();
}
