using System;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AttendanceTime : BaseEntity
{
    public Guid AccountId { get; set; }

    public Guid AttendanceId { get; set; }

    public decimal Minutes { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Attendance? Attendance { get; set; }
}
