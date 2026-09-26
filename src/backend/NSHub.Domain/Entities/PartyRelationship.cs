// <copyright file="PartyRelationship.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a relationship between two parties.
/// </summary>
public class PartyRelationship : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the source party identifier.
    /// </summary>
    public Guid SourcePartyId { get; set; }

    /// <summary>
    /// Gets or sets the target party identifier.
    /// </summary>
    public Guid TargetPartyId { get; set; }

    /// <summary>
    /// Gets or sets the relationship type code.
    /// </summary>
    public string RelationshipTypeCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date from which the relationship is valid.
    /// </summary>
    public DateTime ValidFrom { get; set; }

    /// <summary>
    /// Gets or sets the date until which the relationship is valid.
    /// </summary>
    public DateTime? ValidTo { get; set; }

    /// <summary>
    /// Gets or sets the relationship notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the relationship creation date.
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the source party.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Party? SourceParty { get; set; }

    /// <summary>
    /// Gets or sets the target party.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Party? TargetParty { get; set; }

    /// <summary>
    /// Gets or sets the relationship type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual RelationshipType? RelationshipType { get; set; }
}
