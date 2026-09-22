using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ScrollingTimeTable : BaseEntity
{
    public Guid TimeTableId { get; set; }

    public int Position { get; set; }

    public Guid WorkingTimeGroupId { get; set; }

    public virtual TimeTable? TimeTable { get; set; }

    public virtual WorkingTimeGroup? WorkingTimeGroup { get; set; }
}
