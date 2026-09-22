using System.Collections.Generic;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

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
