using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class PaymentOrderHeader : BaseEntity
{
    public Guid AccountPlanId { get; set; }

    public Guid CheckingAccountId { get; set; }

    public DateTime DateOrder { get; set; }

    public DateTime DateExecution { get; set; }

    public StatusType StatusType { get; set; }

    public string Iso20022Guid { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual AccountPlan? AccountPlan { get; set; }
    public virtual CheckingAccount? CheckingAccount { get; set; }

}
