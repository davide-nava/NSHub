using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class SalaryAccounting : BaseEntity
{

    public Guid SalaryHeadComputingDetailId { get; set; }

    public Guid AccountPlanDebitId { get; set; }

    public Guid AccountPlanCreditId { get; set; }

    public Guid CostCenterId { get; set; }

    public Guid DistributionKeyId { get; set; }

    public Guid SalaryAccountId { get; set; }

    public Guid EmployeeId { get; set; }

    public decimal Amount { get; set; }

    public virtual CostCenter? CostCenter { get; set; }
    public virtual AccountPlan? AccountPlanDebit { get; set; }
    public virtual AccountPlan? AccountPlanCredit { get; set; }
    public virtual SalaryAccount? SalaryAccount { get; set; }
    public virtual SalaryHeadComputingDetail? SalaryHeadComputingDetail { get; set; }
    public virtual Employee? Employee { get; set; }

}
