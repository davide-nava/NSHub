using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PaymentOrderSalaryRow : BaseEntity
{
    public Guid PaymentOrderSalaryHeaderId { get; set; }

    public BankAccountModeType BankAccountModeType { get; set; }

    public bool IsRejected { get; set; }

    public string Iso20022Guid { get; set; } = null!;

    public Iso20022StateType Iso20022StateType { get; set; }

    public DateTime CreditingDate { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public Guid AdditionalId { get; set; }

    public virtual TranslationGroup? Additional { get; set; }

    public virtual PaymentOrderSalaryHeader? PaymentOrderSalaryHeader { get; set; }

}
