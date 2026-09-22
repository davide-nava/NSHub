using System;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceTime : BaseEntity
{
    public Guid AccountId { get; set; }

    public Guid AttendanceId { get; set; }

    public decimal Minutes { get; set; }

    public virtual Account? Account { get; set; }

    public virtual Attendance? Attendance { get; set; }
}
