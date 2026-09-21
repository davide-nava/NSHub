using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class Customer : BaseEntity
{
    public int CustomerId { get; set; }

    public int CompanyId { get; set; }

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? VatNumber { get; set; }

    public string? FiscalCode { get; set; }

    public int? BillingAddressId { get; set; }

    public int? ShippingAddressId { get; set; }

    public int? PaymentTermId { get; set; }

    public bool IsActive { get; set; }

    public virtual Address? BillingAddress { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<CustomerLedgerEntry> CustomerLedgerEntries { get; set; } = [];

    public virtual ICollection<GlJournalLine> GlJournalLines { get; set; } = [];

    public virtual PaymentTerm? PaymentTerm { get; set; }

    public virtual ICollection<SalesInvoiceHeader> SalesInvoiceHeaders { get; set; } = [];

    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = [];

    public virtual ICollection<SalesShipmentHeader> SalesShipmentHeaders { get; set; } = [];
    public virtual Address? ShippingAddress { get; set; }
}
