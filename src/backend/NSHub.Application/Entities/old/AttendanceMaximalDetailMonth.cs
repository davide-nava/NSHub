using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceMaximalDetailMonth : BaseEntity
{
    public Guid AttendanceMaximalDetailId { get; set; }

    public DateTime MonthDate { get; set; }

    public decimal MonthValue { get; set; }

    public virtual AttendanceMaximalDetail? AttendanceMaximalDetail { get; set; }
}
