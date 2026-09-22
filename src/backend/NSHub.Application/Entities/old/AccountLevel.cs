using System;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AccountLevel : BaseEntity
{
    public int LevelNumber { get; set; }

    public Guid DescriptionId { get; set; }

    public bool Enabled { get; set; }

    public Guid ReclassifiedId { get; set; }

    public virtual Fied? Reclassified { get; set; }


    public virtual TranslationGroup? Description { get; set; }
}
