// <copyright file="Warehouse.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Warehouse : BaseEntityType
{

    public Guid? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public Guid? WarehouseTypeId { get; set; }

    public virtual WarehouseType? WarehouseType { get; set; }

}
