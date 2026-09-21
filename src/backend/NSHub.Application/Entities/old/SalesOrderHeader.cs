using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class SalesOrderHeader : BaseEntity
{
    public int SalesOrderId { get; set; }

    public int CompanyId { get; set; }

    public string OrderNumber { get; set; } = null!;

    public DateOnly OrderDate { get; set; }

    public int CustomerId { get; set; }

    public int BusinessUnitId { get; set; }

    public string CurrencyCode { get; set; } = null!;

    public int? PaymentTermId { get; set; }

    public string Status { get; set; } = null!;

    public decimal TotalAmount { get; set; }

    public decimal TotalTaxAmount { get; set; }

    public int CreatedByUserId { get; set; }

    public int? ApprovedByUserId { get; set; }

    public virtual User? ApprovedByUser { get; set; }

    public virtual BusinessUnit BusinessUnit { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual User CreatedByUser { get; set; } = null!;

    public virtual Currency CurrencyCodeNavigation { get; set; } = null!;

    public virtual Customer Customer { get; set; } = null!;

    public virtual PaymentTerm? PaymentTerm { get; set; }

    public virtual ICollection<SalesOrderLine> SalesOrderLines { get; set; } = [];
}
