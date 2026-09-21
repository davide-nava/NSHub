// <copyright file="Region.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Region : BaseEntityType
{


    public Guid? CantonId { get; set; }

    public Guid? CountryId { get; set; }

    public virtual Canton? Canton { get; set; }

    public virtual ICollection<City> Cities { get; set; } = [];

    public virtual Country? Country { get; set; }


}
