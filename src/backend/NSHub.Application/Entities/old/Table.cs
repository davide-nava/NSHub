using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class Table : BaseEntity
{
    public string Code { get; set; } = null!;

    public string Name { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public bool IsSystem { get; set; }

    public string Davers { get; set; } = null!;

    public Guid TableParentId { get; set; }

    public bool IsCustom { get; set; }

    public Guid  CleaningModeTypeId { get; set; }

    public virtual CleaningModeType? CleaningModeType { get; set; }

    public bool IsDefaultCleaning { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Table? TableParent { get; set; }

}
