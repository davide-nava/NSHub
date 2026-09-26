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
    /// Gets the transaction date.
    /// </summary>
    public DateTime? Date { get; protected set; }

    /// <summary>
    /// Gets the balance after the transaction.
    /// </summary>
    public decimal? Balance { get; protected set; }

    /// <summary>
    /// Gets the transaction notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the credited amount.
    /// </summary>
    public decimal? Credit { get; protected set; }

    /// <summary>
    /// Gets the debited amount.
    /// </summary>
    public decimal? Debit { get; protected set; }
}
