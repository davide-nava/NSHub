using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class HolidayTableCache : BaseEntity
{

    public DateTime CreationDate { get; set; }

    public DateTime ComputingDate { get; set; }

    public Guid EmployeeId { get; set; }

    public string ProcessCode { get; set; } = null!;

    public string Content { get; set; } = null!;

    public bool HistoryComputing { get; set; }

    // TODO: Check type
    public int Source { get; set; }

    public bool TimeFormat { get; set; }

    // TODO: Check type
    public int FixedTimeFormat { get; set; }

    public bool SkipForecast { get; set; }

    public virtual Employee? Employee { get; set; }


}
