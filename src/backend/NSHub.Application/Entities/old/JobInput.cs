using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class JobInput : BaseEntity
{
    public Guid AttendanceId { get; set; }

    public IEnumerable<GuidList> Levels { get; set; }

    public decimal TotalCost { get; set; }

    public string ExportRef { get; set; } = null!;

    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public Guid JobActivityScheduleId { get; set; }

    public int PauseMinutes { get; set; }

    public string Remarks { get; set; } = null!;

    public ExportType ExportType { get; set; }

    public Guid EmployeeOnJobEntryId { get; set; }

    public decimal TotalProduced { get; set; }

    public decimal TotalDiscarded { get; set; }

    public decimal Minutes { get; set; }


}
