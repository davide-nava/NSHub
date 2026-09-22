using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class PaymentOrderRow : BaseEntity
{
    public Guid CorrespondentId { get; set; }

    public Guid CorrespondentBankAccountId { get; set; }

    public Guid PaymentOrderHeaderId { get; set; }

    public CorrespondentBankAccountModeType CorrespondentBankAccountModeType { get; set; }

    public decimal AmountDocumentCurrency { get; set; }

    public string Currency { get; set; } = null!;

    public bool IsRejected { get; set; }

    public string Iso20022Guid { get; set; } = null!;

    public Iso20022StateType Iso20022StateType { get; set; }

    public DateTime CreditingDate { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public Guid AdditionalId { get; set; }

    public virtual TranslationGroup? Additional { get; set; }

    public virtual PaymentOrderHeader? PaymentOrderHeader { get; set; }
    public virtual Correspondent? Correspondent { get; set; }
    public virtual CorrespondentBankAccount? CorrespondentBankAccount { get; set; }

}
