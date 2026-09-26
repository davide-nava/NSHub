// <copyright file="Bank.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a bank.
/// </summary>
public class Bank : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the bank name.
    /// </summary>
    public string? Name { get; set; }

    /// <summary>
    /// Gets or sets the SWIFT/BIC code.
    /// </summary>
    public string? SwiftBic { get; set; }

    /// <summary>
    /// Gets or sets the ABI code.
    /// </summary>
    public string? Abi { get; set; }

    /// <summary>
    /// Gets or sets the country code.
    /// </summary>
    public string? CountryCode { get; set; }

    /// <summary>
    /// Gets or sets the bank accounts associated with this bank.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<BankAccount> BankAccounts { get; set; }
        = [];
}
