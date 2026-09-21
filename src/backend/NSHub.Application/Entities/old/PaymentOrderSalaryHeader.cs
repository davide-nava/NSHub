using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PaymentOrderSalaryHeader : BaseEntity
{

    public Guid CheckingAccountId { get; set; }

    public Guid AccountPlanId { get; set; }

    public DateTime DateOrder { get; set; }

    public DateTime DateExecution { get; set; }

    public StatusType StatusType { get; set; }

    public string Iso20022Guid { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


    public virtual CheckingAccount? CheckingAccount { get; set; }
    public virtual AccountPlan? AccountPlan { get; set; }


}
