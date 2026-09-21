using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class Employee : BaseEntity
{
    public int EmployeeId { get; set; }

    public int CompanyId { get; set; }

    public string PersonCode { get; set; } = null!;

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public DateOnly? BirthDate { get; set; }

    public DateOnly HireDate { get; set; }

    public DateOnly? TerminationDate { get; set; }

    public int BusinessUnitId { get; set; }

    public int? UserId { get; set; }

    public virtual BusinessUnit BusinessUnit { get; set; } = null!;

    public virtual Company Company { get; set; } = null!;

    public virtual ICollection<EmployeeAssignment> EmployeeAssignments { get; set; } = [];

    public virtual ICollection<TimesheetHeader> TimesheetHeaders { get; set; } = [];

    public virtual User? User { get; set; }
}
