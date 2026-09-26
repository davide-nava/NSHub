// <copyright file="RelationshipType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a relationship type between two entities.
/// </summary>
public class RelationshipType : AuditableTenantEntity
{
    /// <summary>
    /// Gets the relationship type code.
    /// </summary>
    public string RelationshipTypeCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets the relationship type name.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets the role of the source entity within the relationship.
    /// </summary>
    public string SourceRole { get; set; } = string.Empty;

    /// <summary>
    /// Gets the role of the target entity within the relationship.
    /// </summary>
    public string TargetRole { get; set; } = string.Empty;

    /// <summary>
    /// Gets the relationship description.
    /// </summary>
    public string? Description { get; set; }

}
