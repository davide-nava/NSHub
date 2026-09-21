using System;
using System.Collections.Generic;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class Schedule : BaseEntity
{
    public ScheduleType ScheduleType { get; set; }

    public DateTime From { get; set; }
    public DateTime To { get; set; }

    public DateTime ExecuteFromTime { get; set; }

    public DateTime ExecuteToTime { get; set; }

    public int RepeatEvery { get; set; }

    public int StopAfter { get; set; }

    public bool Enabled { get; set; }

    public int RecurrenceEvery { get; set; }

    public string DaysOfWeek { get; set; } = null!;

    public string MonthsOfYear { get; set; } = null!;

    public string DaysOfMonth { get; set; } = null!;

}
