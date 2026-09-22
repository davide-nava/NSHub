using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class PaymentTerm : BaseEntity
{
    public int PaymentTermId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public int Days { get; set; }

    public bool EndOfMonth { get; set; }

    public virtual ICollection<Customer> Customers { get; set; } = [];

    public virtual ICollection<PurchaseInvoiceHeader> PurchaseInvoiceHeaders { get; set; } = [];

    public virtual ICollection<PurchaseOrderHeader> PurchaseOrderHeaders { get; set; } = [];

    public virtual ICollection<SalesInvoiceHeader> SalesInvoiceHeaders { get; set; } = [];
    public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; } = [];

    public virtual ICollection<Supplier> Suppliers { get; set; } = [];
}
