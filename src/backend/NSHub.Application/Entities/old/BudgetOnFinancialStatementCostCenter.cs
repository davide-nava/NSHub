using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class BudgetOnFinancialStatementCostCenter : BaseEntity
{
    public Guid AccountPlanId { get; set; }

    public Guid CostCenterId { get; set; }

    public DateTime BudgetDate { get; set; }

    public decimal BudgetValue { get; set; }

    public virtual AccountPlan? AccountPlan { get; set; }
    public virtual CostCenter? CostCenter { get; set; }


}
