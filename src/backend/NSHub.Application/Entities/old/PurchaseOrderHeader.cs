using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PurchaseOrderHeader : BaseEntity
{
    public int PurchaseOrderId { get; set; }

    public int CompanyId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    public int SupplierId { get; set; }

    public int BusinessUnitId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public int? PaymentTermId { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal TotalTaxAmount { get; set; }

    public virtual BusinessUnit BusinessUnit { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual Currency CurrencyCodeNavigation { get; set; } = null!;

    public virtual PaymentTerm? PaymentTerm { get; set; }

    public virtual ICollection<PurchaseOrderLine> PurchaseOrderLines { get; set; } = [];

    public virtual Supplier Supplier { get; set; } = null!;
}
