using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class JobActivitySchedule : BaseEntity
{

    public Guid JobActivityId { get; set; }

    public Guid ResourceId { get; set; }

    public int JobMinutes { get; set; }

    public DateTime StartDateTime { get; set; }

    public string Remarks { get; set; } = null!;

    public int PauseMinutes { get; set; }

    public int JobMinutesConsumptive { get; set; }

    public int PauseMinutesConsumptive { get; set; }

    public string ExchangeAppointmentUniqueId { get; set; } = null!;

    public virtual JobActivity? JobActivity { get; set; }
    public virtual Resource? Resource { get; set; }
}
