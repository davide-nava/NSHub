using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceFeedingTimeDetail : BaseEntity
{
    public Guid AttendanceFeedingTimeId { get; set; }

    public int From { get; set; }

    public int Value { get; set; }

    public virtual AttendanceFeedingTime? AttendanceFeedingTime { get; set; }
}
