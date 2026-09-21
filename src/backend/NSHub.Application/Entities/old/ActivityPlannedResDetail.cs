using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ActivityPlannedResDetail : BaseEntity
{
    public Guid ActivityResourceLinkId { get; set; }

    public int PauseMinutes { get; set; }

    public virtual ActivityResourceLink? ActivityResourceLink { get; set; }
}
