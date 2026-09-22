using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceTimeRequest : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public DateTime RequestDate { get; set; }

    public StatusType StatusType { get; set; }

    public Guid AccountId { get; set; }

    public decimal Minutes { get; set; }

    public DateTime LastUpdateDate { get; set; }

    public string Remarks { get; set; } = null!;

    public string LastUpdateUser { get; set; } = null!;

    public DateTime RequestEndDate { get; set; }

    public Guid AttendanceTimeId { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual Account? Account { get; set; }
    public virtual AttendanceTime? AttendanceTime { get; set; }
}
