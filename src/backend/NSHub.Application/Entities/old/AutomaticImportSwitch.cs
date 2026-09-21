using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class AutomaticImportSwitch : BaseEntity
{
    public string Text { get; set; } = null!;

    public PriorityType PriorityType { get; set; }

    public Guid AutomaticImportLayoutId { get; set; }

    public virtual AutomaticImportLayout? AutomaticImportLayout { get; set; }

}
