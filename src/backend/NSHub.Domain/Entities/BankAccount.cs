using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class BankAccount : AuditableTenantEntity
{
    public Guid BankId { get; protected set; }
    public string? AccountHolder { get; protected set; }
    public string Iban { get; protected set; } = string.Empty;
    public string? Abi { get; protected set; }
    public string? Cab { get; protected set; }
    public string? Cin { get; protected set; }
    public string? AccountNumber { get; protected set; }
    public string CurrencyCode { get; protected set; } = string.Empty;
    public bool IsCompanyAccount { get; protected set; }
    public virtual Bank? Bank { get; protected set; }

    private readonly List<Customer> _customers = new();
    public virtual IReadOnlyCollection<Customer> Customers => _customers.AsReadOnly();
    private readonly List<PaymentSchedule> _paymentSchedules = new();
    public virtual IReadOnlyCollection<PaymentSchedule> PaymentSchedules => _paymentSchedules.AsReadOnly();
    private readonly List<Supplier> _suppliers = new();
    public virtual IReadOnlyCollection<Supplier> Suppliers => _suppliers.AsReadOnly();

    protected BankAccount() { }

    public static BankAccount Create()
    {
        return new BankAccount();
    }
}
