using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ReclassifiedMap : BaseEntity
{
    public Guid ReclassifiedId { get; set; }

    public Guid ReclassifiedAccountPlanId { get; set; }

    public Guid AccountPlanId { get; set; }

    public virtual Reclassified? Reclassified { get; set; }

    public virtual ReclassifiedAccountPlan? ReclassifiedAccountPlan { get; set; }

    public virtual AccountPlan? AccountPlan { get; set; }

}
