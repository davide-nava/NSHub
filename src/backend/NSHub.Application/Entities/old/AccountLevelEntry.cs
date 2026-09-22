using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AccountLevelEntry : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid LevelNumberId { get; set; }

    public int LevelGender { get; set; }

    public Guid ParentId { get; set; }

    public Guid ReclassifiedId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual LevelNumber? LevelNumber { get; set; }
    public virtual AccountLevelEntry? Parenti { get; set; }
    public virtual Fied? Reclassified { get; set; }
    public virtual TranslationGroup? Description { get; set; }
}
