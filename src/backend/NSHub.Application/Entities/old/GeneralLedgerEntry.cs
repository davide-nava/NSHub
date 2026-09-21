using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class GeneralLedgerEntry : BaseEntity
{
    public DateTime EntryDate { get; set; }

    public Guid GroupingAccountId { get; set; }

    public decimal AmountCurrentCurrency { get; set; }

    public decimal ExchangeRate { get; set; }

    public decimal AmountBaseCurrency { get; set; }

    public DateTime CompetenceDateFrom { get; set; }

    public DateTime CompetenceDateTo { get; set; }

    public bool IsExtraAccounting { get; set; }

    public decimal AmountVatexcluded { get; set; }


    public virtual GroupingAccount? GroupingAccount { get; set; }
    public virtual Association? Association { get; set; }
    public virtual CostCenter? CostCenter { get; set; }


    public Guid AssociationId { get; set; }

    // TODO: Check type
    public int TransitAccount { get; set; }

    public Guid CostCenterId { get; set; }

    public int Number { get; set; }

    public Guid VatPeriodId { get; set; }
    public bool IsModel { get; set; }


    public ModelType ModelType { get; set; }

    public bool IsFilterByGroupingAccount { get; set; }


    public DateTime CreationDate { get; set; }

    public Guid EmployeeId { get; set; }




    public virtual CostCenter? CostCenter { get; set; }
    public virtual VatPeriod? VatPeriod { get; set; }
    public virtual Employee? Employee { get; set; }



    public Guid DescriptionId { get; set; }
    public Guid DescriptionModelWithMarksId { get; set; }
    public Guid DescriptionModelId { get; set; }
    public Guid DescriptionAdditionalId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual TranslationGroup? DescriptionModelWithMarks { get; set; }
    public virtual TranslationGroup? DescriptionModel { get; set; }
    public virtual TranslationGroup? DescriptionAdditional { get; set; }

}
