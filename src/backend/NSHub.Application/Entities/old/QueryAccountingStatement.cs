using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Bibliography;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class QueryAccountingStatement : BaseEntity
{

    public int RecordNumber { get; set; }

    public RecordType RecordType { get; set; }

    public Guid VatId { get; set; }

    public DateTime DateRecord { get; set; }

    public decimal Credit { get; set; }

    public decimal CreditCurrency { get; set; }

    public decimal Debit { get; set; }

    public decimal DebitCurrency { get; set; }

    public decimal Progressive { get; set; }

    public decimal ProgressiveCurrency { get; set; }

    public decimal ExchangeRate { get; set; }

    public int BulkNumber { get; set; }

    public virtual Vat? Vat { get; set; }
    public virtual AccountPlan? AccountPlan { get; set; }
    public virtual Association? Association { get; set; }
    public virtual Source? Source { get; set; }


    public Guid AccountPlanId { get; set; }

    public Guid AssociationId { get; set; }

    public RecordSubType RecordSubType { get; set; }

    public Guid SourceId { get; set; }

    public bool ExtraAccounting { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public Guid VatPeriodId { get; set; }

    public Guid VatRangeId { get; set; }

    public string CounterpartIds { get; set; } = null!;

    public Guid CostCenterId { get; set; }

    public Guid AccountingId { get; set; }

    public virtual VatPeriod? VatPeriod { get; set; }
    public virtual VatRange? VatRange { get; set; }
    public virtual CostCenter? CostCenter { get; set; }
    public virtual Accounting? Accounting { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public Guid DescriptionAdditionalId { get; set; }

    public virtual TranslationGroup? DescriptionAdditional { get; set; }
}
