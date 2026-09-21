using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Vml.Office;

using Microsoft.AspNetCore.Razor.TagHelpers;

namespace PlanetHub.ApplicationCore.Entities;

public class GeneralLedgerEntryBody : BaseEntity
{
    public Guid EntryId { get; set; }

    public Guid CounterpartId { get; set; }

    // TODO: Check type
    public int Sign { get; set; }

    public Guid VatModeId { get; set; }

    public Guid VatId { get; set; }

    public virtual Entry? Entry { get; set; }
    public virtual Counterpart? Counterpart { get; set; }
    public virtual VatMode? VatMode { get; set; }
    public virtual Vat? Vat { get; set; }


    public string Remark { get; set; } = null!;

    public decimal AmountCurrentCurrency { get; set; }

    public decimal AmountBaseCurrency { get; set; }

    public decimal ExchangeRateCounterpart { get; set; }

    public decimal AmountCounterpart { get; set; }

    public bool IsFixCurrentCurrency { get; set; }

    public bool IsFixBaseCurrency { get; set; }

    public bool IsFixCounterpart { get; set; }

    public decimal ExchangeRate { get; set; }

    public decimal AmountVatexcluded { get; set; }

    public decimal AmountVatexcludedBaseCurrency { get; set; }

    public DateTime LastUpdateDate { get; set; }


    public Guid CostCenterId { get; set; }

    public AdjustmentType AdjustmentType { get; set; }

    // TODO: Check type
    public int VatRatio { get; set; }

    public bool IsKeepPriceCurrentCurrency { get; set; }

    public bool IsKeepPriceCounterpart { get; set; }


    public virtual CostCenter? CostCenter { get; set; }

    public DateTime CompetenceDateFrom { get; set; }

    public DateTime CompetenceDateTo { get; set; }

    public string LastUpdateUser { get; set; } = null!;


    public Guid DescriptionAdditionalId { get; set; }

    public virtual TranslationGroup? DescriptionAdditional { get; set; }

    public Guid DescriptionModelId { get; set; }
    public Guid DescriptionModelWithMarksId { get; set; }

    public virtual TranslationGroup? DescriptionModelWithMarks { get; set; }
    public virtual TranslationGroup? DescriptionModel { get; set; }

    // TODO: Check type
    public int LastUpdateEmployee { get; set; }

}
