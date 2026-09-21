// <copyright file="City.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class City : BaseEntityType
{
    public string? UstNumber { get; set; }

    public string? TaxIdentification { get; set; }

    public string? IstatCode { get; set; }

    public string? PostalCode { get; set; }

    public string? Name { get; set; }

    public Guid? RegionId { get; set; }

    public Guid? CantonId { get; set; }

    public Guid? DistrictId { get; set; }

    public Guid? CountryId { get; set; }

    public virtual Canton? Canton { get; set; }

    public virtual Country? Country { get; set; }

    public virtual District? District { get; set; }

    public virtual Region? Region { get; set; }

}
