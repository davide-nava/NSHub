using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class OvertimeRequestHeader : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public DateTime RequestDate { get; set; }

    public Guid WorkingTimeId { get; set; }

    public StatusType StatusType { get; set; }

    public string Remarks { get; set; } = null!;

    public Guid ClockingId { get; set; }

    public OvertimeModeType OvertimeModeType { get; set; }

    public int TotalTimeRequest { get; set; }

    public DateTime RequestEndDate { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual WorkingTime? WorkingTime { get; set; }
    public virtual Clocking? Clocking { get; set; }


}
