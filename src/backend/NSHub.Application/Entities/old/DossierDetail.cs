using System;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class DossierDetail : BaseEntity
{
    public Guid JobEntryId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual JobEntry? JobEntry { get; set; }

}
