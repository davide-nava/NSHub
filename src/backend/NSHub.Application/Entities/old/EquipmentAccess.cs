using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EquipmentAccess : BaseEntity
{
    public string Code { get; set; }

    public Guid DescriptionId { get; set; }
    public Guid EquipmentId { get; set; }

    public virtual Equipment? Equipment { get; set; }
    public virtual TranslationGroup? Description { get; set; }

}
