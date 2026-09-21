// <copyright file="SalesShipmentLine.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class SalesShipmentLine
{
    public Guid Id { get; set; }

    public Guid? TenantId { get; set; }

    public Guid? UserUpdateId { get; set; }

    public Guid? UserInsertId { get; set; }

    public DateTime DateUpdate { get; set; }

    public DateTime DateInsert { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool IsDeleted { get; set; }

    public bool IsActive { get; set; }

    public Guid SalesShipmentId { get; set; }

    public Guid? SalesOrderLineId { get; set; }

    public Guid ItemId { get; set; }

    public decimal ShippedQuantity { get; set; }

    public Guid UomId { get; set; }
}
