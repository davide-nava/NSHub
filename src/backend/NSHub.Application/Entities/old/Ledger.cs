using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;


public class Ledger : BaseEntity
{

    public GenderType GenderType { get; set; }

    public LedgerType LedgerType { get; set; }

    public bool SendReminder { get; set; }

    public Guid CorrespondentId { get; set; }

    public string Number { get; set; } = null!;

    public DateTime Date { get; set; }

    public Guid PaymentModeId { get; set; }

    public Guid CollectiveAccountId { get; set; }

    public decimal ExchangeRate { get; set; }

    public string Pvreference { get; set; } = null!;

    public decimal TotalBaseCurrency { get; set; }

    public decimal TotalDocumentCurrency { get; set; }

    public decimal BalanceBaseCurrency { get; set; }

    public decimal BalanceDocumentCurrency { get; set; }

    public decimal TotalVatexcluded { get; set; }

    public DateTime CompetenceDateFrom { get; set; }

    public DateTime CompetenceDateTo { get; set; }

    public Guid TransitAccountId { get; set; }

    public bool StopPurchasePayment { get; set; }

    public DateTime NextInstallmentDate { get; set; }

    public decimal NextInstallmentAmount { get; set; }

    public Guid CheckingAccountForPaymentId { get; set; }

    public Guid AccountingNumberId { get; set; }

    public Guid JobEntryId { get; set; }

    public decimal Turnover { get; set; }

    public decimal TurnoverBaseCurrency { get; set; }

    public Guid CorrespondentBankAccountId { get; set; }

    public Guid CorrespondentBankAccountModeId { get; set; }

    public bool VatComputationTypeOnBill { get; set; }

    public bool ExtraAccounting { get; set; }

    public DateTime OnBillDateManager { get; set; }

    public Guid CostCenterId { get; set; }

    public DateTime EffectiveDate { get; set; }

    public Guid LastWorkflowStatusId { get; set; }

    public string LastWorkflowNotes { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public Guid DescriptionAdditionalId { get; set; }

    public virtual TranslationGroup? DescriptionAdditional { get; set; }


}
