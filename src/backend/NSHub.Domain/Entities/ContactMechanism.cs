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
    /// Gets the party identifier.
    /// </summary>
    public Guid PartyId { get; protected set; }

    /// <summary>
    /// Gets the contact channel type code.
    /// </summary>
    public string ContactChannelTypeCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the contact value.
    /// </summary>
    public string ContactValue { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets the usage description.
    /// </summary>
    public string? UsageDescription { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether this is the default contact mechanism.
    /// </summary>
    public bool IsDefault { get; protected set; }

    /// <summary>
    /// Gets a value indicating whether the contact mechanism has been verified.
    /// </summary>
    public bool IsVerified { get; protected set; }

    /// <summary>
    /// Gets additional notes.
    /// </summary>
    public string? Notes { get; protected set; }

    /// <summary>
    /// Gets the creation date.
    /// </summary>
    public DateTimeOffset CreatedOn { get; protected set; }

    /// <summary>
    /// Gets the contact channel type.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual ContactChannelType? ContactChannelType { get; protected set; }

    /// <summary>
    /// Gets the associated party.
    /// Virtual navigation property used by EF Core.
    /// </summary>
    public virtual Party? Party { get; protected set; }
}
