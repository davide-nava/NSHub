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
    /// Gets or sets the supplier name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the search text used for filtering and lookup.
    /// </summary>
    public string? Search { get; set; }

    /// <summary>
    /// Gets or sets the supplier number.
    /// </summary>
    public string? Number { get; set; }

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
    /// Gets or sets the address identifier.
    /// </summary>
    public Guid? AddressId { get; set; }

    /// <summary>
    /// Gets or sets the payment method identifier.
    /// </summary>
    public Guid? PaymentId { get; set; }

    /// <summary>
    /// Gets or sets the bank account identifier.
    /// </summary>
    public Guid? BankAccountId { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the supplier is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the associated bank account.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual BankAccount? BankAccount { get; set; }

    /// <summary>
    /// Gets or sets the associated payment method.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Payment? Payment { get; set; }

    /// <summary>
    /// Gets or sets the supplier address.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Address? Address { get; set; }

    /// <summary>
    /// Gets or sets the articles associated with this supplier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Article> Articles { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the purchase orders associated with this supplier.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Order> Orders { get; set; }
        = [];
}
