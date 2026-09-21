using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EmployeeUnavailability : BaseEntity
{

    public Guid EmployeeId { get; set; }

    public int DayOfWeek { get; set; }

    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public virtual Employee? Employee { get; set; }

}
