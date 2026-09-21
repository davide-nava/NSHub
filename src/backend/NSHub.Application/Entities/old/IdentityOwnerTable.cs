using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class IdentityOwnerTable : BaseEntity
{
    public Guid SurrogateIdentityId { get; set; }

    public Guid SurrogateLockOwnerId { get; set; }

    public virtual SurrogateIdentity? SurrogateIdentity { get; set; }
    public virtual SurrogateLockOwner? SurrogateLockOwner { get; set; }

}
