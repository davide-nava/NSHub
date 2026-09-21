using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class GenericObjectStatus : BaseEntity
{
    public StatusType StatusType { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
