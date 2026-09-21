// <copyright file="PurchaseReceiptHeader.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class PurchaseReceiptHeader
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

    public Guid CompanyId { get; set; }

    public string ReceiptNumber { get; set; } = null!;

    public DateOnly ReceiptDate { get; set; }

    public Guid SupplierId { get; set; }

    public Guid WarehouseId { get; set; }

    public string Status { get; set; } = null!;
}
