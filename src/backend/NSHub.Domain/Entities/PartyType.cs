// <copyright file="PartyType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a party type.
/// </summary>
public class PartyType : AuditableTenantEntity
{
    /// <summary>
    /// Gets the party type code.
    /// </summary>
    public string PartyTypeCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets the party type name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the party type description.
    /// </summary>
    public string? Description { get; set; }

    /// <summary>
    /// Gets the parties associated with this party type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<Party> Parties { get; protected set; }
        = new List<Party>();
}
