using System;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class DossierDetail : BaseEntity
{
    public Guid JobEntryId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual JobEntry? JobEntry { get; set; }

}
