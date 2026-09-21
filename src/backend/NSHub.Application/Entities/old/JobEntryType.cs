using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class JobEntryType : BaseEntity
{
    public bool CreatePlanning { get; set; }

    public string RegCategories { get; set; } = null!;


    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
