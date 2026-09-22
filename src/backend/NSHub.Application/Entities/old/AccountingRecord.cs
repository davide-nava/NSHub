using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AccountingRecord : BaseEntity
{
    public int Number { get; set; }

    public DateTime RecordDate { get; set; }

    public Guid DebitAccountId { get; set; }

    public Guid CreditAccountId { get; set; }

    public Guid VatId { get; set; }

    public VatModeType VatModeType { get; set; }

    public decimal AmountBaseCurrency { get; set; }

    public decimal AmountDebitForeignCurrency { get; set; }

    public decimal AmountCreditForeignCurrency { get; set; }

    public decimal ExchangeRateDebit { get; set; }

    public decimal ExchangeRateCredit { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public decimal AmountBaseCurrencyVatExcluded { get; set; }

    public bool AccountingError { get; set; }

    public Guid AssociationId { get; set; }

    public int TechnicalField { get; set; }

    public Guid VatPeriodId { get; set; }

    public bool IsIncomplete { get; set; }

    public Guid CostCenterId { get; set; }

    public int VatRatio { get; set; }

    public bool IsExtraAccounting { get; set; }

    public decimal AmountForeignCurrency { get; set; }

    public decimal ExchangeRate { get; set; }

    public string LastUpdateUser { get; set; } = null!;

    public int LastUpdateEmployee { get; set; }

    public Guid DescriptionAdditionalId { get; set; }

    public virtual TranslationGroup? DescriptionAdditional { get; set; }


    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
