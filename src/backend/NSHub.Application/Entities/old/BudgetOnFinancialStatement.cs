using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class BudgetOnFinancialStatement : BaseEntity
{
    public Guid AccountPlanId { get; set; }

    public DateTime BudgetDate { get; set; }

    public decimal BudgetValue { get; set; }

    public virtual AccountPlan? AccountPlan { get; set; }

}
