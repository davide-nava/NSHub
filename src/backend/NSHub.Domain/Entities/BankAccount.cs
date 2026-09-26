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
    /// Gets or sets the bank identifier.
    /// </summary>
    public Guid BankId { get; set; }

    /// <summary>
    /// Gets or sets the account holder name.
    /// </summary>
    public string? AccountHolder { get; set; }

    /// <summary>
    /// Gets or sets the IBAN.
    /// </summary>
    public string Iban { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the ABI code.
    /// </summary>
    public string? Abi { get; set; }

    /// <summary>
    /// Gets or sets the CAB code.
    /// </summary>
    public string? Cab { get; set; }

    /// <summary>
    /// Gets or sets the CIN code.
    /// </summary>
    public string? Cin { get; set; }

    /// <summary>
    /// Gets or sets the account number.
    /// </summary>
    public string? AccountNumber { get; set; }

    /// <summary>
    /// Gets or sets the account currency code.
    /// </summary>
    public string CurrencyCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets a value indicating whether the account belongs to the company.
    /// </summary>
    public bool IsCompanyAccount { get; set; }

    /// <summary>
    /// Gets or sets the associated bank.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Bank? Bank { get; set; }
}
