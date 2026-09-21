// <copyright file="WorkplaceType.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class WorkplaceType : BaseEntityType
{

    public virtual ICollection<Warehouse> Warehouses { get; set; } = [];


}
