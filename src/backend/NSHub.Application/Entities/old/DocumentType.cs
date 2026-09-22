using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class DocumentType : BaseEntity
{
    public Guid LinkCode { get; set; }

    public bool DossierUpdate { get; set; }

    public bool DossierInternalNumberUpdate { get; set; }

    public Guid NumeratorId { get; set; }
    public virtual Numerator? Numerator { get; set; }


    public bool IsPrintRounding { get; set; }

    public Guid RegCategoryGroupId { get; set; }

    public Guid WarehouseAccountId { get; set; }

    public AccountingType AccountingType { get; set; }

    public virtual RegCategoryGroup? RegCategoryGroup { get; set; }
    public virtual WarehouseAccount? WarehouseAccount { get; set; }




    public Guid DescriptionHeaderId { get; set; }

    public virtual TranslationGroup? DescriptionHeader { get; set; }

    public Guid DescriptionFooterId { get; set; }
    public virtual TranslationGroup? DescriptionFooter { get; set; }



    public DocumentDateModeType DocumentDateModeType { get; set; }

    public int ExpiringDays { get; set; }

    public ProvisionEvasionTotalModeType ProvisionEvasionTotalModeType { get; set; }

    public Guid ProvisionEvasionProvisionsFilter { get; set; }

    public ProvisionEvasionGroupType ProvisionEvasionGroupType { get; set; }

    public bool ProvisionEvasionIsChangeSign { get; set; }

    public Guid TemplateMailId { get; set; }

    public virtual TemplateMail? TemplateMail { get; set; }


    public RegistrationType RegistrationType { get; set; }

    public Guid ArticleId { get; set; }

    public virtual Article? Article { get; set; }

    public string ReportPvrchf { get; set; } = null!;

    public string ReportPvreur { get; set; } = null!;

    public string ReportNoPvr { get; set; } = null!;

    public string ReportEmail { get; set; } = null!;

    public string Code { get; set; } = null!;

    public bool IsChangeSignEdit { get; set; }

    public CreateJobCodeModeType CreateJobCodeModeType { get; set; }

    public Guid JobEntryTypeId { get; set; }

    public virtual JobEntryType? JobEntryType { get; set; }

    public bool IsCheckCreditLimit { get; set; }

    public bool IsSynchPrices { get; set; }
    public int CheckMinimumPrice { get; set; }

    public int UpdatePurchasingPrice { get; set; }

    public bool IsCreatePriceList { get; set; }

    public bool IsSupplying { get; set; }

    public int IdDefaultSupplyingType { get; set; }

    public bool IsWorkflowPrint { get; set; }

    public bool IsWorkflowClosingBody { get; set; }

    public bool IsWorkflowEvasion { get; set; }

    public bool IsWorkflowManual { get; set; }

    public Guid WorkflowModelId { get; set; }

    public virtual WorkflowModel? WorkflowModel { get; set; }

    public bool IsSubscription { get; set; }

    public int WarningBillRecall { get; set; }

    public bool InternalJob { get; set; }

    public bool AccountingCompFromDocDate { get; set; }

    public bool UpdateCorrespondentLastDocumentDates { get; set; }

    public bool UpdateArticleLastDocumentDates { get; set; }

    public bool IsPrepaidAutomaticEvasion { get; set; }

    public bool IsRoundVat { get; set; }

    public bool CloseDocumentBodyAfterEvasion { get; set; }

    public string Reports { get; set; } = null!;

    public string PrepaidDocTypeId { get; set; } = null!;

    public UpdatePurchasingPriceModeType UpdatePurchasingPriceModeType { get; set; }

    public bool UpdateSupplyingPrice { get; set; }

    public string DocumentBodyHeader { get; set; } = null!;

    public DeliverAttachmentsModeType DeliverAttachmentsModeType { get; set; }

    public DeliverAttachmentsTemplateMailModeType DeliverAttachmentsTemplateMailModeType { get; set; }

    public Guid DeliverAttachmentsFilter { get; set; }

    public bool DeliverAttachmentsPrint { get; set; }

    public IEnumerable<BoolGroupList> CorrespondentBlocks { get; set; }


    public int ProvisionEvasionFromDateFieldName { get; set; }

    public int ProvisionEvasionToDateFieldName { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public Guid DescriptionVideoId { get; set; }

    public virtual TranslationGroup? DescriptionVideo { get; set; }


}
