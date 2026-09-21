// <copyright file="Address.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Address : BaseEntity
{
    public DateTime ValidFrom { get; set; }

    public DateTime ValidTo { get; set; }

    public string Street { get; set; } = null!;

    public string PostOfficeBox { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Locality { get; set; } = null!;

    public string Text { get; set; } = null!;

    public Guid? CityId { get; set; }

    public Guid? AddressTypeId { get; set; }

    public virtual AddressType? AddressType { get; set; }

    public virtual ICollection<Warehouse> Warehouses { get; set; } = [];
}
