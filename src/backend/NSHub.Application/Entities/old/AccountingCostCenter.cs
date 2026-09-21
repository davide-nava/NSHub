using System;

using DocumentFormat.OpenXml.Bibliography;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AccountingCostCenter : BaseEntity
{
    public Guid LevelId { get; set; }

    public Guid SourceId { get; set; }

    public Guid CostCenterId { get; set; }

    public DateTime RecordDate { get; set; }

    public Guid AccountingId { get; set; }

    public Guid AccountPlanId { get; set; }

    public decimal AmountBaseCurrency { get; set; }

    public virtual CostCenter? CostCenter { get; set; }
    public virtual Source? Source { get; set; }
    public virtual Level? Level { get; set; }
    public virtual Accounting? Accounting { get; set; }
    public virtual AccountPlan? AccountPlan { get; set; }

}
