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
    /// Gets the bank name.
    /// </summary>
    public string? Name { get; protected set; }

    /// <summary>
    /// Gets the SWIFT/BIC code.
    /// </summary>
    public string? SwiftBic { get; protected set; }

    /// <summary>
    /// Gets the ABI code.
    /// </summary>
    public string? Abi { get; protected set; }

    /// <summary>
    /// Gets the country code.
    /// </summary>
    public string? CountryCode { get; protected set; }

    /// <summary>
    /// Gets the bank accounts associated with this bank.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<BankAccount> BankAccounts { get; protected set; }
        = new List<BankAccount>();
}
