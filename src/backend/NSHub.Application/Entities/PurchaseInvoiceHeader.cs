// <copyright file="PurchaseInvoiceHeader.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class PurchaseInvoiceHeader
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

    public string InvoiceNumber { get; set; } = null!;

    public DateOnly InvoiceDate { get; set; }

    public Guid SupplierId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public Guid? PaymentTermId { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal TotalTaxAmount { get; set; }
}
