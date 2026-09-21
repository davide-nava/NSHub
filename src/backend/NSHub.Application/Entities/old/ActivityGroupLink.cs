using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ActivityGroupLink : BaseEntity
{
    public Guid ActivityManagementId { get; set; }

    public Guid GroupId { get; set; }

    public LinkType LinkType { get; set; }

    public virtual ActivityManagement? ActivityManagement { get; set; }

    public virtual Group? Group { get; set; }
}
