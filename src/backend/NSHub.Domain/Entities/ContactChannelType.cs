// <copyright file="ContactChannelType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a contact channel type.
/// </summary>
public class ContactChannelType : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the contact channel type code.
    /// </summary>
    public string ContactChannelTypeCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description.
    /// </summary>
    public string? Description { get; set; }
}
