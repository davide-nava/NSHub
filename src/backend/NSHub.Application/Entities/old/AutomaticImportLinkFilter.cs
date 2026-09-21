using System;
using System.Collections.Generic;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AutomaticImportLinkFilter : BaseEntity
{
    public Guid TableId { get; set; }

    public string FieldName { get; set; } = null!;

    public PriorityType PriorityType { get; set; }

    public Guid AutomaticImportLayoutId { get; set; }

    public virtual AutomaticImportLayout? AutomaticImportLayout { get; set; }
    public virtual Table? Table { get; set; }
}
