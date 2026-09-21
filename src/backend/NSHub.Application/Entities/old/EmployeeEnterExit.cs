using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EmployeeEnterExit : BaseEntity
{

    public Guid EmployeeId { get; set; }

    public DateTime EnterDate { get; set; }

    public DateTime ExitDate { get; set; }

    public string ReferenceHr { get; set; }

    public DateTime EnterDateHoliday { get; set; }

    public DateTime ExitDateHoliday { get; set; }

    public bool UseForSalary { get; set; }

    public virtual Employee? Employee { get; set; }


}
