using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class LedgerBody : BaseEntity
{
    public Guid LedgerId { get; set; }

    public Guid BodyTypeId { get; set; }

    public DateTime BodyDate { get; set; }

    public Guid CounterPartId { get; set; }

    public decimal AmountBaseCurrency { get; set; }

    public decimal AmountDocumentCurrency { get; set; }

    public decimal AmountCounterPart { get; set; }

    public decimal ExchangeRate { get; set; }

    public decimal ExchangeRateCounterpart { get; set; }

    public bool CurrencyManagerFixCurrency { get; set; }

    public bool CurrencyManagerFixCounterPart { get; set; }

    public bool CurrencyManagerFixCollectiveAccount { get; set; }

    public Guid VatId { get; set; }

    public IEnumerable<TranslationGroupList> AdditionalTexts { get; set; }


    public decimal AmountVatexcluded { get; set; }

    public Guid TransferLedgerId { get; set; }

    public Guid TransferBodyLedgerId { get; set; }

    public decimal AmountVatexcludedBaseCurrency { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public string RefExternal { get; set; } = null!;

    public bool ExcludeFromTurnover { get; set; }

    public Guid AssociationId { get; set; }

    public Guid CostCenterId { get; set; }

    public Guid VatPeriodId { get; set; }

    // TODO: Check type
    public int VatRatio { get; set; }

    public Guid PaymentOrderHeaderId { get; set; }

    public DateTime CompetenceDateFrom { get; set; }

    public DateTime CompetenceDateTo { get; set; }

    public string LastUpdateUser { get; set; } = null!;

    public Guid LastUpdateEmployee { get; set; }

    public bool ExcludeFromDiscountDivision { get; set; }

}
