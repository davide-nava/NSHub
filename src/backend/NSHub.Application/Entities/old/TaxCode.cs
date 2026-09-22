using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class TaxCode : BaseEntity
{
    public Guid CompanyId { get; set; }

    public string Code { get; set; } = null!;

    public string Description { get; set; } = null!;

    public decimal RatePercent { get; set; }

    public int? TaxAccountId { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<PurchaseInvoiceLine> PurchaseInvoiceLines { get; set; } = [];

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = [];

    public virtual ICollection<SalesInvoiceLine> SalesInvoiceLines { get; set; } = [];

    public virtual ICollection<SalesOrderLine> SalesOrderLines { get; set; } = [];
    public virtual GlAccount? TaxAccount { get; set; }
}
