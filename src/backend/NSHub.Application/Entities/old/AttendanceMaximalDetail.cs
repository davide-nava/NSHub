using System.Collections.Generic;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AttendanceMaximalDetail : BaseEntity
{
    public Guid AttendanceMaximalId { get; set; }

    public int Year { get; set; }

    public DaysModeType DaysModeType { get; set; }

    public decimal TotalHours { get; set; }

    public decimal DailyWorkingMinutes { get; set; }

    public decimal DaysOff { get; set; }

    public virtual AttendanceMaximal? AttendanceMaximal { get; set; }

}
