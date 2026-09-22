using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class FinancialStatement : BaseEntity
{
    public Guid AccountPlanId { get; set; }

    public int BulkNumber { get; set; }

    public IEnumerable<DecimalList> BalanceCurrencies { get; set; }
    public IEnumerable<DecimalList> Balances { get; set; }
    public IEnumerable<DecimalList> BudgetAmounts { get; set; }

    public decimal BalanceDebt { get; set; }

    public decimal BalanceCredit { get; set; }

    public virtual AccountPlan? AccountPlan { get; set; }


}
