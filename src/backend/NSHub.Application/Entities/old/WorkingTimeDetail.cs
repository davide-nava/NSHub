using System;

namespace PlanetHub.ApplicationCore.Entities;

public class WorkingTimeDetail : BaseEntity
{
    public Guid WorkingTimeId { get; set; }

    public Guid TimeZoneId { get; set; }

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public bool CheckInRounding { get; set; }

    public bool CheckInRebate { get; set; }

    public bool CheckOutRounding { get; set; }

    public bool CheckOutRebate { get; set; }

    public bool CheckInRebateOnBandStart { get; set; }

    public bool CheckOutRebateOnBandEnd { get; set; }

    public bool CheckInExpected { get; set; }

    public bool CheckOutExpected { get; set; }

    public bool InDontApplyOnJobsComputing { get; set; }

    public bool OutDontApplyOnJobsComputing { get; set; }

    public bool BandStart { get; set; }

    public bool BandFinish { get; set; }

    public bool CoversNeed { get; set; }

    public virtual TimeZone? TimeZone { get; set; }

    public virtual WorkingTime? WorkingTime { get; set; }
}
