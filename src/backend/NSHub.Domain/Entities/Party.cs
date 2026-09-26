// <copyright file="Party.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a party within the system.
/// </summary>
public class Party : AuditableTenantEntity
{
    /// <summary>
    /// Gets the internal code.
    /// </summary>
    public string? InternalCode { get; protected set; }

    /// <summary>
    /// Gets the party type code.
    /// </summary>
    public string PartyTypeCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the display name.
    /// </summary>
    public string DisplayName { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the tax identification number.
    /// </summary>
    public string? TaxIdentificationNumber { get; protected set; }

    /// <summary>
    /// Gets the VAT number.
    /// </summary>
    public string? VatNumber { get; protected set; }

    /// <summary>
    /// Gets additional notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the party is active.
    /// </summary>
    public bool IsActive { get; protected set; }

    /// <summary>
    /// Gets the creation date.
    /// </summary>
    public DateTimeOffset CreatedOn { get; protected set; }

    /// <summary>
    /// Gets the last update date.
    /// </summary>
    public DateTimeOffset UpdatedOn { get; protected set; }

    /// <summary>
    /// Gets the associated person.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Person? Person { get; protected set; }

    /// <summary>
    /// Gets the associated organization.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Organization? Organization { get; protected set; }

    /// <summary>
    /// Gets the associated party type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PartyType? PartyType { get; protected set; }

    /// <summary>
    /// Gets the relationships where this party is the source.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<PartyRelationship> SourceRelationships { get; protected set; }
        = new List<PartyRelationship>();

    /// <summary>
    /// Gets the relationships where this party is the target.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<PartyRelationship> TargetRelationships { get; protected set; }
        = new List<PartyRelationship>();
}
