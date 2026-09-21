using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class SubjectLevel : BaseEntity
{
    public Guid PriorityTypeId { get; set; }

    public virtual PriorityType? PriorityType { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
