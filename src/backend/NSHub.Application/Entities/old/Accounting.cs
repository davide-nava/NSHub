using System;

using DocumentFormat.OpenXml.Bibliography;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class Accounting : BaseEntity
{
    public decimal AmountBaseCurrency { get; set; }

    public decimal AmountForeignCurrency { get; set; }

    public DateTime DateRecord { get; set; }

    public decimal ExchangeRate { get; set; }

    public Guid AccountPlanId { get; set; }

    public Guid SourceId { get; set; }

    public Guid VatId { get; set; }





    public RecordType RecordType { get; set; }

    public RecordSubType RecordSubType { get; set; }

    public bool TechnicalField { get; set; }

    public Guid VatPeriodId { get; set; }

    public string VatGroup { get; set; } = null!;

    public bool Extra { get; set; }

    public decimal TaxableAmount { get; set; }

    public Guid TaxableAccountId { get; set; }

    public Guid AssociationId { get; set; }






    public string CounterpartIds { get; set; } = null!;

    public Guid CostCenterId { get; set; }

    public string VatStatementGroup { get; set; } = null!;

    public bool VatManagerTypeChanged { get; set; }

    public CompetenceRowType CompetenceRowType { get; set; }

    public virtual AccountPlan? AccountPlan { get; set; }

    public virtual Source? Source { get; set; }
    public virtual Vat? Vat { get; set; }

    public virtual VatPeriod? VatPeriod { get; set; }

    public virtual TaxableAccount? TaxableAccount { get; set; }
    public virtual Association? Association { get; set; }
    public virtual CostCenter? CostCenter { get; set; }
}
