// <copyright file="ContactMechanism.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents a contact mechanism associated with a party.
/// </summary>
public class ContactMechanism : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the party identifier.
    /// </summary>
    public Guid PartyId { get; set; }

    /// <summary>
    /// Gets or sets the contact channel type code.
    /// </summary>
    public string ContactChannelTypeCode { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the contact value.
    /// </summary>
    public string ContactValue { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the usage description.
    /// </summary>
    public string? UsageDescription { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether this is the default contact mechanism.
    /// </summary>
    public bool IsDefault { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the contact mechanism has been verified.
    /// </summary>
    public bool IsVerified { get; set; }

    /// <summary>
    /// Gets or sets additional notes.
    /// </summary>
    public string? Notes { get; set; }

    /// <summary>
    /// Gets or sets the creation date.
    /// </summary>
    public DateTimeOffset CreatedOn { get; set; }

    /// <summary>
    /// Gets or sets the contact channel type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ContactChannelType? ContactChannelType { get; set; }

    /// <summary>
    /// Gets or sets the associated party.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Party? Party { get; set; }
}
