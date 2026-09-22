// <copyright file="InvoiceStatus.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using System.Text.Json.Serialization;

namespace NSHub.Domain.Enums;

/// <summary>
/// Lifecycle statuses of a sales invoice.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum InvoiceStatus
{
    /// <summary>
    /// Draft invoice. Lines can be added, updated, or removed.
    /// </summary>
    Draft = 1,

    /// <summary>
    /// Issued invoice. Legally binding and locked; lines cannot be modified.
    /// </summary>
    Issued = 2,

    /// <summary>
    /// Settled invoice with payment confirmed.
    /// </summary>
    Paid = 3,

    /// <summary>
    /// Cancelled or credited invoice.
    /// </summary>
    Cancelled = 4,
}
