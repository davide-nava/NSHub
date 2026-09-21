
using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class PlanningResourceType : BaseEntityType
{

    public Guid ColorTypeId { get; set; }
    public virtual ColorType? ColorType { get; set; }
}
