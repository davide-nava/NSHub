using System;

namespace PlanetHub.ApplicationCore.Entities;

public class VatRange : BaseEntity
{
    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public decimal Percentage { get; set; }

    public Guid VatId { get; set; }

    public Guid CounterpartTypeId { get; set; }

    public virtual CounterpartType? CounterpartType { get; set; }

    public Guid CounterpartId { get; set; }

    public Guid DescriptionId { get; set; }

    public bool EnablePreviousRate { get; set; }

    public bool EnableNextRate { get; set; }

    public string VatStatementCode { get; set; } = null!;

    public decimal PercentageVatFree { get; set; }

    public string Code { get; set; } = null!;

    public bool IsExcludeDiscountSplit { get; set; }

    public bool IncludeIn205 { get; set; }

    public virtual Vat? Vat { get; set; }

    // TODO: manca la tabella
    //public virtual Counterpart? Counterpart { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
