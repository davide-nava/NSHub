using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ActivityResourceLink : BaseEntity
{
    public Guid ActivityManagementId { get; set; }

    public Guid ActivityPlannedResDetailId { get; set; }

    public Guid ResourceId { get; set; }

    public Guid EmployeeId { get; set; }

    public LinkType LinkType { get; set; }

    public virtual ActivityManagement? ActivityManagement { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Resource? Resource { get; set; }

    public virtual ActivityPlannedResDetail? ActivityPlannedResDetail { get; set; }
}
