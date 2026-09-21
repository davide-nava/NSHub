using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class ScrollingTimeTable : BaseEntity
{
    public Guid TimeTableId { get; set; }

    public int Position { get; set; }

    public Guid WorkingTimeGroupId { get; set; }

    public virtual TimeTable? TimeTable { get; set; }

    public virtual WorkingTimeGroup? WorkingTimeGroup { get; set; }
}
