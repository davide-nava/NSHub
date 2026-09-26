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
    /// Gets the source party identifier.
    /// </summary>
    public Guid SourcePartyId { get; protected set; }

    /// <summary>
    /// Gets the target party identifier.
    /// </summary>
    public Guid TargetPartyId { get; protected set; }

    /// <summary>
    /// Gets the relationship type code.
    /// </summary>
    public string RelationshipTypeCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the date from which the relationship is valid.
    /// </summary>
    public DateTime ValidFrom { get; protected set; }

    /// <summary>
    /// Gets the date until which the relationship is valid.
    /// </summary>
    public DateTime? ValidTo { get; protected set; }

    /// <summary>
    /// Gets the relationship notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the relationship creation date.
    /// </summary>
    public DateTimeOffset CreatedOn { get; protected set; }

    /// <summary>
    /// Gets the source party.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Party? SourceParty { get; protected set; }

    /// <summary>
    /// Gets the target party.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Party? TargetParty { get; protected set; }

    /// <summary>
    /// Gets the relationship type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual RelationshipType? RelationshipType { get; protected set; }
}
