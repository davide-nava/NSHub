// <copyright file="SalesOrderLine.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class SalesOrderLine
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

    public Guid SalesOrderId { get; set; }

    public Guid LineNumber { get; set; }

    public Guid ItemId { get; set; }

    public string Description { get; set; } = null!;

    public decimal OrderedQuantity { get; set; }

    public Guid UomId { get; set; }

    public decimal UnitPrice { get; set; }

    public decimal DiscountPercent { get; set; }

    public Guid? TaxCodeId { get; set; }

    public Guid WarehouseId { get; set; }

    public decimal LineAmount { get; set; }

    public decimal LineTaxAmount { get; set; }
}
