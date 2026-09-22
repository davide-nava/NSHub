using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class GroupActivityDefault : BaseEntity
{
    public Guid GroupId { get; set; }

    public Guid PlannedTypeId { get; set; }

    public Guid ActivityTypeId { get; set; }

    public string PrimaryResources { get; set; } = null!;

    public string SecondaryResources { get; set; } = null!;

    public virtual Group? Group { get; set; }
    public virtual PlannedType? PlannedType { get; set; }
    public virtual ActivityType? ActivityType { get; set; }

}
