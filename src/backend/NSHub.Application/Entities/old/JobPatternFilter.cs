using System;

using NSHub.ApplicationCore.Entities;

namespace NSHub.ApplicationCore.Entities;

public class JobPatternFilter : BaseEntity
{
    public string Expression { get; set; } = null!;

    public string ExpressionReadyToUse { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
