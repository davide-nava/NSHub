using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class EquipmentDetail : BaseEntity
{
    public Guid EquipmentId { get; set; }

    public bool Backlight { get; set; }

    public string LastConfiguration { get; set; } = null!;

    public string CustomConfigurationParameters { get; set; } = null!;

    public int Number { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual Equipment? Equipment { get; set; }

}
