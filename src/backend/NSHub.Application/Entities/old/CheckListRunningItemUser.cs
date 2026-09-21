using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class CheckListRunningItemUser : BaseEntity
{
    public Guid ItemId { get; set; }

    public Guid EmployeeId { get; set; }

    public StatusType StatusType { get; set; }

    public bool IsActive { get; set; }

    public string Note { get; set; } = null!;

    public DateTime DateAndTime { get; set; }

    public Guid EmployeeApprovatorId { get; set; }


    public virtual Item? Item { get; set; }
    public virtual Employee? Employee { get; set; }
    public virtual EmployeeApprovator? EmployeeApprovator { get; set; }

}
