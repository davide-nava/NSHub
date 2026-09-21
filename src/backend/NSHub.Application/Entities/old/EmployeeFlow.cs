using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EmployeeFlow : BaseEntity
{

    public Guid EmployeeId { get; set; }

    public EmployeeFlowType EmployeeFlowType { get; set; }

    public string Url { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual Employee? Employee { get; set; }
}
