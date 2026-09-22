using System;

namespace NSHub.ApplicationCore.Entities;

public class CostCenterBodyCostCenter : BaseEntity
{
    public Guid CostCenteId { get; set; }
    public Guid CostCenterBodyId { get; set; }
    public virtual CostCente? CostCente { get; set; }
    public virtual CostCenterBody? CostCenterBody { get; set; }

}
