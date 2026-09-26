// <copyright file="AuditableLookupEntity.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Domain.Common;

/// <summary>
/// Represents a base class for lookup entities, providing common properties such as description, sort order, and default selection status.
/// </summary>
public class AuditableLookupEntity : AuditableTenantEntity, IAuditableLookupEntity
{
    /// <summary>
    /// Gets or sets the name of the lookup item.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the code of the lookup item.
    /// </summary>
    public string Code { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the sort order of the lookup item.
    /// </summary>
    public int Sort { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the lookup item is the default selection.
    /// </summary>
    public bool IsDefault { get; set; }
}
