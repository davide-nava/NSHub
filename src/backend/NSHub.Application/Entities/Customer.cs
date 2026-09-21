// <copyright file="Customer.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

namespace NSHub.Application.Entities;

public class Customer
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

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? VatNumber { get; set; }

    public string? FiscalCode { get; set; }

    public Guid? BillingAddressId { get; set; }

    public Guid? ShippingAddressId { get; set; }

    public Guid? PaymentTermId { get; set; }
}
