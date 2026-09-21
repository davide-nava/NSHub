using System;
using System.Collections.Generic;

using PlanetHub.Models.EntityModels;

namespace PlanetHub.ApplicationCore.Entities;

public class Address : BaseEntityModel
{
    public string Line1 { get; set; } = null!;

    public string? Line2 { get; set; }

    public string City { get; set; } = null!;

    public string ZipCode { get; set; } = null!;

    public string? Province { get; set; }

    public string CountryCode { get; set; } = null!;

    public Guid AddressTypeId { get; set; }

    public virtual AddressType? AddressType { get; set; }

    public virtual ICollection<Company> Companies { get; set; } = [];

    public virtual ICollection<Customer> CustomerBillingAddresses { get; set; } = [];

    public virtual ICollection<Customer> CustomerShippingAddresses { get; set; } = [];

    public virtual ICollection<Supplier> Suppliers { get; set; } = [];

    public virtual ICollection<Warehouse> Warehouses { get; set; } = [];
}
