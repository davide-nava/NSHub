// <copyright file="Supplier.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Supplier : AuditableTenantEntity
{
    public string Name { get; protected set; } = string.Empty;
    public string? Search { get; protected set; }
    public string? Number { get; protected set; }
    public string? VatNumber { get; protected set; }
    public string? TaxCode { get; protected set; }
    public string? SdiCode { get; protected set; }
    public string? PecEmail { get; protected set; }
    public string? Email { get; protected set; }
    public string? Phone { get; protected set; }
    public Guid? AddressId { get; protected set; }
    public Guid? PaymentId { get; protected set; }
    public Guid? BankAccountId { get; protected set; }
    public bool IsActive { get; protected set; }
    public virtual BankAccount? BankAccount { get; protected set; }
    public virtual Payment? Payment { get; protected set; }

    private readonly List<Invoice> _invoices = new();
    public virtual IReadOnlyCollection<Invoice> Invoices => _invoices.AsReadOnly();
    private readonly List<Order> _orders = new();
    public virtual IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();

    protected Supplier() { }

    public static Supplier Create()
    {
        return new Supplier();
    }
}
