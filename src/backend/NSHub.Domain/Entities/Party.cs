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
    /// Gets or sets the internal code.
    /// </summary>
    public string? InternalCode { get; set; }

    /// <summary>
    /// Gets or sets the party type code.
    /// </summary>
    public string PartyTypeCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the display name.
    /// </summary>
    public string DisplayName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the tax identification number.
    /// </summary>
    public string? TaxIdentificationNumber { get; set; }

    /// <summary>
    /// Gets or sets the VAT number.
    /// </summary>
    public string? VatNumber { get; set; }

    /// <summary>
    /// Gets or sets additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the party is active.
    /// </summary>
    public bool IsActive { get; set; }

    /// <summary>
    /// Gets or sets the creation date.
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the last update date.
    /// </summary>
    public DateTimeOffset UpdatedOn { get; set; }

    /// <summary>
    /// Gets or sets the associated person.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Person? Person { get; set; }

    /// <summary>
    /// Gets or sets the associated organization.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Organization? Organization { get; set; }

    /// <summary>
    /// Gets or sets the associated party type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual PartyType? PartyType { get; set; }

    /// <summary>
    /// Gets or sets the relationships where this party is the source.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<PartyRelationship> SourceRelationships { get; set; }
        = [];

    /// <summary>
    /// Gets or sets the relationships where this party is the target.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ICollection<PartyRelationship> TargetRelationships { get; set; }
        = [];
}
