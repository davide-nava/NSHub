// <copyright file="District.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class District : BaseEntityType
{



    public virtual ICollection<City> Cities { get; set; } = [];

}
