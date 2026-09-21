// <copyright file="InvoiceStatus.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Invoicing.Enums;

/// <summary>
/// Lifecycle statuses of a sales invoice.
/// </summary>
public enum InvoiceStatus
{
    /// <summary>
    /// Draft invoice. Lines can be added, updated, or removed.
    /// </summary>
    DRAFT = 1,

    /// <summary>
    /// Issued invoice. Legally binding and locked; lines cannot be modified.
    /// </summary>
    ISSUED = 2,

    /// <summary>
    /// Settled invoice with payment confirmed.
    /// </summary>
    PAID = 3,

    /// <summary>
    /// Cancelled or credited invoice.
    /// </summary>
    CANCELLED = 4
}
