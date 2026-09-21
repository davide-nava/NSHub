// <copyright file="InventoryTransaction.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class InventoryTransaction
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

    public Guid ItemId { get; set; }

    public Guid WarehouseId { get; set; }

    public Guid? LocationId { get; set; }

    public DateTime TransactionDate { get; set; }

    public decimal Quantity { get; set; }

    public string TransactionType { get; set; } = null!;

    public string? ReferenceDocumentType { get; set; }

    public Guid? ReferenceDocumentId { get; set; }

    public decimal? UnitCost { get; set; }

    public Guid CreatedByUserId { get; set; }
}
