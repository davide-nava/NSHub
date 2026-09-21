using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CostCenterBody : BaseEntity
{

    public Guid CostHeaderId { get; set; }


    public decimal Amount { get; set; }

    public virtual CostHeader? CostHeader { get; set; }


}
