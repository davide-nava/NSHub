using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AutomaticImportField : BaseEntity
{
    public Guid TableId { get; set; }

    public string FieldName { get; set; } = null!;

    public string FixedValue { get; set; } = null!;

    public Guid AutomaticImportLayoutId { get; set; }

    public virtual AutomaticImportLayout? AutomaticImportLayout { get; set; }

    public virtual Table? Table { get; set; }

}
