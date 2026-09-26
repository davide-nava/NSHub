// <copyright file="Vat.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a VAT rate.
/// </summary>
public class Vat : AuditableTenantEntity
{
    /// <summary>
    /// Gets the VAT description.
    /// </summary>
    public string Description { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the VAT percentage value.
    /// </summary>
    public decimal Value { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether this is the default VAT rate.
    /// </summary>
    public bool IsDefault { get; protected set; }
}
