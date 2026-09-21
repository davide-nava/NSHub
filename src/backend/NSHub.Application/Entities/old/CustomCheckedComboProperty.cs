using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CustomCheckedComboProperty : BaseEntity
{
    public Guid FieldId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Field? Field { get; set; }

}

