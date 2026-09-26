// <copyright file="BankAccount.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a bank account.
/// </summary>
public class BankAccount : AuditableTenantEntity
{
    /// <summary>
    /// Gets the bank identifier.
    /// </summary>
    public Guid BankId { get; protected set; }

    /// <summary>
    /// Gets the account holder name.
    /// </summary>
    public string? AccountHolder { get; protected set; }

    /// <summary>
    /// Gets the IBAN.
    /// </summary>
    public string Iban { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the ABI code.
    /// </summary>
    public string? Abi { get; protected set; }

    /// <summary>
    /// Gets the CAB code.
    /// </summary>
    public string? Cab { get; protected set; }

    /// <summary>
    /// Gets the CIN code.
    /// </summary>
    public string? Cin { get; protected set; }

    /// <summary>
    /// Gets the account number.
    /// </summary>
    public string? AccountNumber { get; protected set; }

    /// <summary>
    /// Gets the account currency code.
    /// </summary>
    public string CurrencyCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets a value indicating whether the account belongs to the company.
    /// </summary>
    public bool IsCompanyAccount { get; protected set; }

    /// <summary>
    /// Gets the associated bank.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Bank? Bank { get; protected set; }
}
