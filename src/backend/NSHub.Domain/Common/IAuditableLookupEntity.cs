// <copyright file="IAuditableLookupEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Defines the contract for lookup entities.
/// </summary>
public interface IAuditableLookupEntity
{
    /// <summary>
    /// Gets or sets the description of the lookup item.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Gets or sets the lookup code.
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Gets or sets the display order.
    /// </summary>
    public int Sort { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this item is the default one.
    /// </summary>
    public bool IsDefault { get; set; }
}
