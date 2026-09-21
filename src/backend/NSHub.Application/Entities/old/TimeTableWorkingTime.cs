using System;

namespace PlanetHub.ApplicationCore.Entities;

public class TimeTableWorkingTime : BaseEntity
{
    public Guid WorkingTimeId { get; set; }

    public Guid TimeTableWorkingTimeTypeId { get; set; }

    public virtual TimeTableWorkingTimeType? TimeTableWorkingTimeType { get; set; }

    public Guid WorkingTimeGroupId { get; set; }

    public virtual WorkingTimeGroup? WorkingTimeGroup { get; set; }

    public virtual WorkingTime? WorkingTime { get; set; }
}
