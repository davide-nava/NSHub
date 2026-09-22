// <copyright file="CashLedger.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a cash ledger entry.
/// </summary>
public class CashLedger : BaseEntity
{
    /// <summary>Gets or sets the date.</summary>
    public DateTime? Date { get; set; }

    /// <summary>Gets or sets the balance.</summary>
    public decimal? Balance { get; set; }

    /// <summary>Gets or sets notes.</summary>
    public string? Notes { get; set; }

    /// <summary>Gets or sets credit amount (Avere).</summary>
    public decimal? Credit { get; set; }

    /// <summary>Gets or sets debit amount (Dare).</summary>
    public decimal? Debit { get; set; }
}
