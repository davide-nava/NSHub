// <copyright file="Vat.cs" company="Davide Nava">
// Copyright (c) Davide Nava. All rights reserved.
// </copyright>

using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Vat : AuditableTenantEntity
{
    public string Description { get; protected set; } = string.Empty;
    public decimal Value { get; protected set; }
    public bool IsDefault { get; protected set; }

    private readonly List<Customer> _customers = new();
    public virtual IReadOnlyCollection<Customer> Customers => _customers.AsReadOnly();
    private readonly List<Invoice> _invoices = new();
    public virtual IReadOnlyCollection<Invoice> Invoices => _invoices.AsReadOnly();
    private readonly List<InvoiceRow> _invoiceRows = new();
    public virtual IReadOnlyCollection<InvoiceRow> InvoiceRows => _invoiceRows.AsReadOnly();
    private readonly List<OrderRow> _orderRows = new();
    public virtual IReadOnlyCollection<OrderRow> OrderRows => _orderRows.AsReadOnly();
    private readonly List<Quotation> _quotations = new();
    public virtual IReadOnlyCollection<Quotation> Quotations => _quotations.AsReadOnly();

    protected Vat() { }

    public static Vat Create()
    {
        return new Vat();
    }
}
