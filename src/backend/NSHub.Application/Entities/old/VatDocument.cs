using System;

namespace PlanetHub.ApplicationCore.Entities;

public class VatDocument : BaseEntity
{
    public Guid DocumentId { get; set; }

    public Guid VatId { get; set; }

    public Guid VatRangeId { get; set; }

    public decimal Taxable { get; set; }

    public decimal TaxableCurrency { get; set; }

    public decimal TotalVatIncluded { get; set; }

    public decimal TotalCurrencyVatIncluded { get; set; }

    public virtual VatRange? VatRange { get; set; }

    public virtual Document? Document { get; set; }

    public virtual Vat? Vat { get; set; }
}
