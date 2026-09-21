using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class JobPosition : BaseEntity
{
    public int JobPositionId { get; set; }

    public int CompanyId { get; set; }

    public string Code { get; set; } = null!;

    public string Title { get; set; } = null!;

    public string? Description { get; set; }

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<EmployeeAssignment> EmployeeAssignments { get; set; } = [];
}
