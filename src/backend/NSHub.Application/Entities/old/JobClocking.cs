using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class JobClocking : BaseEntity
{
    public string BadgeNumber { get; set; } = null!;

    public DateTime DateAndTime { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid SourceId { get; set; }

    public string MachineCode { get; set; } = null!;

    public DateTime? CmpTheDate { get; set; }

    public Guid JobClockingTypeId { get; set; }


    public IEnumerable<GuidList> JobLevels { get; set; }


    public string SourceDetails { get; set; } = null!;

    public short EquipmentNumber { get; set; }

    public short EquipmentDetailsNumber { get; set; }

    public decimal LocationLatitude { get; set; }

    public decimal LocationLongitude { get; set; }

    public decimal LocationAccuracy { get; set; }

    public bool LocationOutOfRange { get; set; }

    public string Notes { get; set; } = null!;

    public bool TimeIsNotReliable { get; set; }

    public decimal PartDiscarded { get; set; }

    public decimal PartProduced { get; set; }


}
