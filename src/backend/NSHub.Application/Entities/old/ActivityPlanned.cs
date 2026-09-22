using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ActivityPlanned : BaseEntity
{
    public Guid ActivityId { get; set; }

    public string SubjectTitle { get; set; } = null!;

    public string SubjectName { get; set; } = null!;

    public string CustomerNote { get; set; } = null!;

    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public string Venue { get; set; } = null!;

    public string Locality { get; set; } = null!;

    public string PostalCode { get; set; } = null!;

    public string Address { get; set; } = null!;

    public string Reason { get; set; } = null!;

    public Guid VenueId { get; set; }

    public string DayTime { get; set; } = null!;

    public Guid SourcePlanningId { get; set; }

    public ConfirmModeType ConfirmModeType { get; set; }

    public virtual ActivityManagement? ActivityManagement { get; set; }

}
