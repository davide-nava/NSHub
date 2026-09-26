// <copyright file="Address.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Address : AuditableTenantEntity
{
    public Guid PartyId { get; protected set; }
    public Guid AddressTypeId { get; protected set; }
    public Guid? NationId { get; protected set; }
    public string StreetName { get; protected set; } = string.Empty;
    public string? BuildingNumber { get; protected set; }
    public string? AddressLine2 { get; protected set; }
    public string PostalCode { get; protected set; } = string.Empty;
    public string City { get; protected set; } = string.Empty;
    public string? StateProvince { get; protected set; }
    public string CountryCode { get; protected set; } = string.Empty;
    public string? CareOf { get; protected set; }
    public DateTime ValidFrom { get; protected set; }
    public DateTime? ValidTo { get; protected set; }
    public bool IsDefault { get; protected set; }
    public string? Street { get; protected set; }
    public string? StreetNumber { get; protected set; }
    public string? ZipCode { get; protected set; }
    public string? Province { get; protected set; }
    public virtual AddressType? AddressType { get; protected set; }
    public virtual Nation? Nation { get; protected set; }
    public virtual Party? Party { get; protected set; }

    private readonly List<Warehouse> _warehouses = new();
    public virtual IReadOnlyCollection<Warehouse> Warehouses => _warehouses.AsReadOnly();

    protected Address() { }

    public static Address Create()
    {
        return new Address();
    }
}
