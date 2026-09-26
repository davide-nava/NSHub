// <copyright file="Supplier.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a supplier.
/// </summary>
public class Supplier : AuditableTenantEntity
{
    /// <summary>
    /// Gets the supplier name.
    /// </summary>
    public string Name { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the search text used for filtering and lookup.
    /// </summary>
    public string? Search { get; protected set; }

    /// <summary>
    /// Gets the supplier number.
    /// </summary>
    public string? Number { get; protected set; }

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
    /// Gets the address identifier.
    /// </summary>
    public Guid? AddressId { get; protected set; }

    /// <summary>
    /// Gets the payment method identifier.
    /// </summary>
    public Guid? PaymentId { get; protected set; }

    /// <summary>
    /// Gets the bank account identifier.
    /// </summary>
    public Guid? BankAccountId { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the supplier is active.
    /// </summary>
    public bool IsActive { get; protected set; }

    /// <summary>
    /// Gets the associated bank account.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual BankAccount? BankAccount { get; protected set; }

    /// <summary>
    /// Gets the associated payment method.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Payment? Payment { get; protected set; }

    /// <summary>
    /// Gets the supplier address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? Address { get; protected set; }

    /// <summary>
    /// Gets the articles associated with this supplier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> Articles { get; protected set; }
        = new List<Article>();

    /// <summary>
    /// Gets the purchase orders associated with this supplier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Order> Orders { get; protected set; }
        = new List<Order>();
}
