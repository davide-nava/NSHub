// <copyright file="Payment.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Payment : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;
    public int? Days { get; protected set; }

    private readonly List<Customer> _customers = new();
    public virtual IReadOnlyCollection<Customer> Customers => _customers.AsReadOnly();
    private readonly List<Invoice> _invoices = new();
    public virtual IReadOnlyCollection<Invoice> Invoices => _invoices.AsReadOnly();
    private readonly List<Order> _orders = new();
    public virtual IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
    private readonly List<Quotation> _quotations = new();
    public virtual IReadOnlyCollection<Quotation> Quotations => _quotations.AsReadOnly();
    private readonly List<Supplier> _suppliers = new();
    public virtual IReadOnlyCollection<Supplier> Suppliers => _suppliers.AsReadOnly();

    protected Payment() { }

    public static Payment Create()
    {
        return new Payment();
    }
}
