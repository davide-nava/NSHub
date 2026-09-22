using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class GeoTrackingClocking : BaseEntity
{
    public DateTime DateAndTime { get; set; }

    public Guid EmployeeId { get; set; }

    public decimal LocationLatitude { get; set; }

    public decimal LocationLongitude { get; set; }

    public decimal LocationAccuracy { get; set; }

    public virtual Employee? Employee { get; set; }
}
