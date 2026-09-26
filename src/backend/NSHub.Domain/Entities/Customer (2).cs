using System;
using System.Collections.Generic;
using NSHub.Domain.Common;

namespace NSHub.Domain.Entities;

public class Customer : AuditableTenantEntity
{
    public string Code { get; protected set; } = string.Empty;
    public string CompanyName { get; protected set; } = string.Empty;
    public string? VatNumber { get; protected set; }
    public string? TaxCode { get; protected set; }
    public string? SdiCode { get; protected set; }
    public string? PecEmail { get; protected set; }
    public string? Email { get; protected set; }
    public string? Phone { get; protected set; }
    public string? Website { get; protected set; }
    public Guid? LegalAddressId { get; protected set; }
    public Guid? ShippingAddressId { get; protected set; }
    public Guid? PaymentId { get; protected set; }
    public Guid? VatId { get; protected set; }
    public Guid? BankAccountId { get; protected set; }
    public decimal? CreditLimit { get; protected set; }
    public bool IsActive { get; protected set; }
    public string? Notes { get; protected set; }
    public virtual BankAccount? BankAccount { get; protected set; }
    public virtual Payment? Payment { get; protected set; }
    public virtual Vat? Vat { get; protected set; }

    private readonly List<DeliveryNote> _goodsDeliveryNotes = new();
    public virtual IReadOnlyCollection<DeliveryNote> GoodsDeliveryNotes => _goodsDeliveryNotes.AsReadOnly();
    private readonly List<DeliveryNote> _invoiceDeliveryNotes = new();
    public virtual IReadOnlyCollection<DeliveryNote> InvoiceDeliveryNotes => _invoiceDeliveryNotes.AsReadOnly();
    private readonly List<Document> _documents = new();
    public virtual IReadOnlyCollection<Document> Documents => _documents.AsReadOnly();
    private readonly List<Invoice> _invoices = new();
    public virtual IReadOnlyCollection<Invoice> Invoices => _invoices.AsReadOnly();
    private readonly List<Machine> _machines = new();
    public virtual IReadOnlyCollection<Machine> Machines => _machines.AsReadOnly();
    private readonly List<Order> _orders = new();
    public virtual IReadOnlyCollection<Order> Orders => _orders.AsReadOnly();
    private readonly List<Quotation> _quotations = new();
    public virtual IReadOnlyCollection<Quotation> Quotations => _quotations.AsReadOnly();
    private readonly List<Shipment> _shipments = new();
    public virtual IReadOnlyCollection<Shipment> Shipments => _shipments.AsReadOnly();
    private readonly List<Ticket> _tickets = new();
    public virtual IReadOnlyCollection<Ticket> Tickets => _tickets.AsReadOnly();

    protected Customer() { }

    public static Customer Create(
        string code,
        string companyName,
        string? vatNumber = null,
        string? taxCode = null,
        string? email = null,
        string? phone = null,
        decimal? creditLimit = null)
    {
        return new Customer
        {
            Code = code,
            CompanyName = companyName,
            VatNumber = vatNumber,
            TaxCode = taxCode,
            Email = email,
            Phone = phone,
            CreditLimit = creditLimit,
            IsActive = true
        };
    }

    public void UpdateContactInfo(string? email, string? phone, string? website)
    {
        Email = email;
        Phone = phone;
        Website = website;
    }

    public void UpdateCreditLimit(decimal? creditLimit)
    {
        CreditLimit = creditLimit;
    }

    public void Deactivate()
    {
        IsActive = false;
    }

    public void Activate()
    {
        IsActive = true;
    }
}
