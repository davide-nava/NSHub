using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EquipmentAccessEmployee : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public Guid EquipmentId { get; set; }

    public bool IsActive { get; set; }

    public string Pin { get; set; } = null!;

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public int TimeEnd { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual Equipment? Equipment { get; set; }

}
