// <copyright file="CashBook.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a cash book entry.
/// </summary>
public class CashBook : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the transaction date.
    /// </summary>
    public DateTime? Date { get; set; }

    /// <summary>
    /// Gets or sets the balance after the transaction.
    /// </summary>
    public decimal? Balance { get; set; }

    /// <summary>
    /// Gets or sets the transaction notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the credited amount.
    /// </summary>
    public decimal? Credit { get; set; }

    /// <summary>
    /// Gets or sets the debited amount.
    /// </summary>
    public decimal? Debit { get; set; }
}
