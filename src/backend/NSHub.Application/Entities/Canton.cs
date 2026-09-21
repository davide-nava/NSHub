// <copyright file="Canton.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Canton : BaseEntityType
{

    public virtual ICollection<City> Cities { get; set; } = [];

    public virtual ICollection<Region> Regions { get; set; } = [];

}
