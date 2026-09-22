using System;
using System.Collections.Generic;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class Document : BaseEntity
{
    public DateTime Date { get; set; }

    public string Number { get; set; } = null!;

    public DocumentType DocumentType { get; set; }

    public string CollectiveAccount { get; set; } = null!;


    public Guid DocumentId { get; set; }

    public Guid DocumentTypeId { get; set; }

    public string Number { get; set; } = null!;

    public DateTime DocumentDate { get; set; }

    public Guid WarehouseAccountId { get; set; }

    public Guid AccountPlanId { get; set; }

    public decimal ExchangeRate { get; set; }

    public Guid PaymentModeId { get; set; }

    public DateTime ExpiringDate { get; set; }

    public string Header { get; set; } = null!;

    public string Footer { get; set; } = null!;

    public IEnumerable<TranslationGroupList> Texts { get; set; }

    public IEnumerable<TranslationGroupList> Notes { get; set; }

    public Guid JobEntryId { get; set; }

    public Guid AgentId { get; set; }

    public Guid AgentCommissionId { get; set; }

    public IEnumerable<StringGroupList> CorrespondentCodes { get; set; }

    public IEnumerable<DateTimeList> CorrespondentDates { get; set; }

    public IEnumerable<StringGroupList> CorrespondentTexts { get; set; }

    public IEnumerable<DecimalList> DiscountPercentages { get; set; }
    public IEnumerable<DecimalList> DiscountAmounts { get; set; }
    public IEnumerable<GuidList> DiscountModes { get; set; }


    public IEnumerable<DecimalList> SubtotalVatExcludeds { get; set; }
    public IEnumerable<DecimalList> SubtotalVatIncludeds { get; set; }

    public IEnumerable<DecimalList> SubtotalVatExcludedCurrencies { get; set; }

    public IEnumerable<DecimalList> SubtotalVatIncludedCurrencies { get; set; }



    public IEnumerable<DecimalList> TotalVatExcludeds { get; set; }
    public IEnumerable<DecimalList> TotalVatIncludeds { get; set; }

    public IEnumerable<DecimalList> TotalVatExcludedCurrencies { get; set; }

    public IEnumerable<DecimalList> TotalVatIncludedCurrencies { get; set; }


    public string Language { get; set; } = null!;

    public IEnumerable<DecimalList> DiscountVatExcludeds { get; set; }
    public IEnumerable<DecimalList> DiscountVatIncludeds { get; set; }

    public IEnumerable<DecimalList> DiscountVatExcludedCurrencies { get; set; }

    public IEnumerable<DecimalList> DiscountVatIncludedCurrencies { get; set; }

    public Guid CheckingAccountId { get; set; }

    public Guid CheckingAccountPaymentTypeId { get; set; }

    public Guid DefaultUserWarehouseId { get; set; }

    public Guid AccountingNumberId { get; set; }

    public int ProcessingStatus { get; set; }

    public IEnumerable<DecimalList> CorrespondentAmountBcs { get; set; }
    public IEnumerable<DecimalList> CorrespondentAmountFcs { get; set; }

    public Guid LedgerId { get; set; }

    public DateTime NextInstallmentDate { get; set; }

    public decimal NextInstallmentAmount { get; set; }

    public decimal Turnover { get; set; }

    public decimal TurnoverBaseCurrency { get; set; }

    public decimal NetTotal { get; set; }

    public Guid CostCenterId { get; set; }

    public DateTime PrintingDate { get; set; }

    public Guid ProcessedId { get; set; }

    public DateTime CustomDataProssima { get; set; }

    public int CustomFrequenzaMesi { get; set; }

    public DateTime CustomDataUltEsecuz { get; set; }

    public Guid BillingCorrespondentId { get; set; }

    public Guid PriceListId { get; set; }

    public Guid LastWorkflowStatusId { get; set; }

    public string LastWorkflowNotes { get; set; } = null!;

    public DateTime ScanDate { get; set; }

    public string Pvreference { get; set; } = null!;

    public int IdGenericObject { get; set; }

    public int Counter { get; set; }

    public int CreationUser { get; set; }

    public int IdDocumentAddNotes { get; set; }

    public int IdEmployee { get; set; }

    public int IdMedidataTicket { get; set; }

    public int IdDefaultCorrespondentWarehouse { get; set; }

    public int IdCorrespondentBankAccount { get; set; }

    public int CorrespondentBankAccountMode { get; set; }

    public int CreationEmployee { get; set; }

    public int EditEmployee { get; set; }

    public virtual TbDocumentType DocumentTypeNavigation { get; set; } = null!;

    public virtual TbAccountPlan IdAccountPlanNavigation { get; set; } = null!;

}
