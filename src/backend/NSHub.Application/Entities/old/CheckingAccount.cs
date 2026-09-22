using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CheckingAccount : BaseEntity
{
    public string InstitutionName { get; set; } = null!;

    public string InstitutionAddress { get; set; } = null!;

    public string InstitutionLocality { get; set; } = null!;

    public Guid AccountPlanId { get; set; }

    public string Iban { get; set; } = null!;

    public string ReferenceLine { get; set; } = null!;

    public Guid ReferenceLineTypeId { get; set; }

    public string Pvrfolder { get; set; } = null!;

    public PvType PvType { get; set; }

    public IEnumerable<TranslationGroupList> PaymentLines { get; set; }

    public int DocumentNumber { get; set; }

    public IEnumerable<TranslationGroupList> BeneficiaryLines { get; set; }


    public string FolderName { get; set; } = null!;

    public string FileName { get; set; } = null!;

    public string Dtacode { get; set; } = null!;

    public bool RemoveZeros { get; set; }

    public string FollowerNumber { get; set; } = null!;

    public string YellownetNumber { get; set; } = null!;

    public string YellownetUser { get; set; } = null!;

    public string YellownetPassword { get; set; } = null!;

    public bool YellownetConfirmPayment { get; set; }

    public bool YellownetConfirmOrder { get; set; }

    public bool YellownetConfirmExecution { get; set; }

    public bool YellownetPvrreader { get; set; }

    public bool YellownetAccountBalance { get; set; }

    public bool YellownetSalesWarning { get; set; }

    public bool YellownetPurchaseWarning { get; set; }

    public bool IgnoreCorrespondent { get; set; }

    public PaymentModeType PaymentModeType { get; set; }

    public bool BatchBooking { get; set; }

    public int OrderAdvice { get; set; }

    public string Swift { get; set; } = null!;

    public string Qriban { get; set; } = null!;

    public string AdditionalQrcodeInfo { get; set; } = null!;

    public string SalaryFolderName { get; set; } = null!;

    public string SalaryFileName { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
