// <copyright file="Address.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

/// <summary>
/// Represents an address entity in the domain model.
/// </summary>
public class Address : AuditableTenantEntity
{
    /// <summary>
    /// Gets or sets the identifier of the party associated with the address.
    /// </summary>
    public Guid PartyId { get; protected set; }

    /// <summary>
    /// Gets or sets the identifier of the address type associated with the address.
    /// </summary>
    public Guid AddressTypeId { get; protected set; }

    /// <summary>
    /// Gets or sets the identifier of the nation associated with the address.
    /// </summary>
    public Guid? NationId { get; protected set; }

    /// <summary>
    /// Gets or sets the name of the street for the address.
    /// </summary>
    public string StreetName { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets or sets the building number for the address.
    /// </summary>
    public string? BuildingNumber { get; protected set; }

    /// <summary>
    /// Gets or sets the first line of the address.
    /// </summary>
    public string? AddressLine2 { get; protected set; }

    /// <summary>
    /// Gets or sets the second line of the address.
    /// </summary>
    public string PostalCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets or sets the city for the address.
    /// </summary>
    public string City { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets or sets the state or province for the address.
    /// </summary>
    public string? StateProvince { get; protected set; }

    /// <summary>
    /// Gets or sets the country code for the address.
    /// </summary>
    public string CountryCode { get; protected set; } = string.Empty;

    /// <summary>
    /// Gets or sets the care of information for the address.
    /// </summary>
    public string? CareOf { get; protected set; }

    /// <summary>
    /// Gets or sets the date from which the address is valid.
    /// </summary>
    public DateTime ValidFrom { get; protected set; }

    /// <summary>
    /// Gets or sets the date until which the address is valid. If null, the address is considered valid indefinitely.
    /// </summary>
    public DateTime? ValidTo { get; protected set; }

    /// <summary>
    /// Gets or sets a value indicating whether this address is the default address for the associated party.
    /// </summary>
    public bool IsDefault { get; protected set; }

    /// <summary>
    /// Gets or sets the street name for the address.
    /// </summary>
    public string? Street { get; protected set; }

    /// <summary>
    /// Gets or sets the street number for the address.
    /// </summary>
    public string? StreetNumber { get; protected set; }

    /// <summary>
    /// Gets or sets the zip code for the address.
    /// </summary>
    public string? ZipCode { get; protected set; }

    /// <summary>
    /// Gets or sets the province for the address.
    /// </summary>
    public string? Province { get; protected set; }

    /// <summary>
    /// Gets or sets the address type associated with the address.
    /// </summary>
    public virtual AddressType? AddressType { get; protected set; }

    /// <summary>
    /// Gets or sets the nation associated with the address.
    /// </summary>
    public virtual Nation? Nation { get; protected set; }

    /// <summary>
    /// Gets or sets the party associated with the address.
    /// </summary>
    public virtual Party? Party { get; protected set; }
}
