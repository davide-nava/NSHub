using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EquipmentAccessDetail : BaseEntity
{

    public Guid EquipmentAccessId { get; set; }

    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public string Days { get; set; } = null!;

    public string Readers { get; set; } = null!;

    public ClockingModeType ClockingModeType { get; set; }

    public virtual EquipmentAccess? EquipmentAccess { get; set; }
}
