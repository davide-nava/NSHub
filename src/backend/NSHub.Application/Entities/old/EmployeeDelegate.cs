using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EmployeeDelegate : BaseEntity
{
    public Guid SeekerId { get; set; }

    public Guid SubstituteId { get; set; }

    public DateTime DateFrom { get; set; }

    public DateTime DateTo { get; set; }

    public int Form { get; set; }

    public virtual Seeker? Seeker { get; set; }
    public virtual Substitute? Substitute { get; set; }


}
