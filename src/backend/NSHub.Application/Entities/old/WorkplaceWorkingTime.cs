using System;

using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class WorkplaceWorkingTime : BaseEntity
{
    public Guid WorkplaceId { get; set; }

    public decimal WeeklyHours { get; set; }

    public decimal WeeklyLessons { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual Workplace? Workplace { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
