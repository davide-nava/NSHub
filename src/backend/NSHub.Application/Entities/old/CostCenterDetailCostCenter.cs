using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CostCenterDetailCostCenter : BaseEntity
{
    public Guid CostCenterDetailId { get; set; }

    public Guid CostCenterId { get; set; }

    public decimal Percentage { get; set; }

    public virtual CostCenter? CostCenter { get; set; }
    public virtual CostCenterDetail? CostCenterDetail { get; set; }
}
