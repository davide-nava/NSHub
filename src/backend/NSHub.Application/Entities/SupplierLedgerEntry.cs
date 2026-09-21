// <copyright file="SupplierLedgerEntry.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class SupplierLedgerEntry
{
    public Guid Id { get; set; }

    public Guid? TenantId { get; set; }

    public Guid? UserUpdateId { get; set; }

    public Guid? UserInsertId { get; set; }

    public DateTime DateUpdate { get; set; }

    public DateTime DateInsert { get; set; }

    public DateTime? DateDeleted { get; set; }

    public bool IsDeleted { get; set; }

    public byte[]? Version { get; set; }

    public bool IsActive { get; set; }

    public Guid CompanyId { get; set; }

    public Guid SupplierId { get; set; }

    public string DocumentType { get; set; } = null!;

    public Guid DocumentId { get; set; }

    public DateOnly PostingDate { get; set; }

    public decimal Amount { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public bool IsOpen { get; set; }
}
