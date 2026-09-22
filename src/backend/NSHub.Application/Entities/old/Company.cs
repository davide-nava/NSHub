using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class Company : BaseEntity
{

    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string? VatNumber { get; set; }

    public string? FiscalCode { get; set; }

    public Guid? AddressId { get; set; }

    public virtual Address? Address { get; set; }

    public virtual ICollection<BusinessUnit> BusinessUnits { get; set; } = [];

    public virtual ICollection<CustomerLedgerEntry> CustomerLedgerEntries { get; set; } = [];

    public virtual ICollection<Customer> Customers { get; set; } = [];

    public virtual ICollection<Employee> Employees { get; set; } = [];

    public virtual ICollection<GlAccount> GlAccounts { get; set; } = [];

    public virtual ICollection<GlJournalHeader> GlJournalHeaders { get; set; } = [];

    public virtual ICollection<GlPeriod> GlPeriods { get; set; } = [];

    public virtual ICollection<ItemGroup> ItemGroups { get; set; } = [];
    public virtual ICollection<Item> Items { get; set; } = [];

    public virtual ICollection<JobPosition> JobPositions { get; set; } = [];

    public virtual ICollection<PurchaseInvoiceHeader> PurchaseInvoiceHeaders { get; set; } = [];
    public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = [];

    public virtual ICollection<PurchaseReceiptHeader> PurchaseReceiptHeaders { get; set; } = [];

    public virtual ICollection<SalesInvoiceHeader> SalesInvoiceHeaders { get; set; } = [];
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = [];

    public virtual ICollection<SalesShipmentHeader> SalesShipmentHeaders { get; set; } = [];

    public virtual ICollection<SupplierLedgerEntry> SupplierLedgerEntries { get; set; } = [];
    public virtual ICollection<Supplier> Suppliers { get; set; } = [];

    public virtual ICollection<TaxCode> TaxCodes { get; set; } = [];

    public virtual ICollection<Warehouse> Warehouses { get; set; } = [];
}
