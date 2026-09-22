using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomModToMod : BaseEntity
{
    public Guid CustomModToModParentId { get; set; }

    public string Code { get; set; } = null!;

    public string rand { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual CustomModToMod? CustomModToModParent { get; set; }

}
