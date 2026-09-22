
using NSHub.ApplicationCore.Entities;

namespace NSHub.ApplicationCore.Entities;

public class PlanningResourceType : BaseEntityType
{

    public Guid ColorTypeId { get; set; }
    public virtual ColorType? ColorType { get; set; }
}
