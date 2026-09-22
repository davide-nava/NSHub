using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CostCenterDetail : BaseEntity
{
    public Guid CostCenterHeaderId { get; set; }

    public decimal Percentage { get; set; }

    public virtual CostCenterHeader? CostCenterHeader { get; set; }
}
