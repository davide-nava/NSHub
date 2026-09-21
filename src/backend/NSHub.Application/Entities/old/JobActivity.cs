using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class JobActivity : BaseEntity
{
    public IEnumerable<GuidList> JobLevels { get; set; }

    public Guid JobPlanningId { get; set; }

    public Guid ResourceId { get; set; }

    public Guid ResourceTypeId { get; set; }

    public int JobMinutes { get; set; }

    public PlanningType PlanningType { get; set; }

    public DateTime StartTime { get; set; }

    public DateTime ExpectedPlanningDate { get; set; }

    public bool Closed { get; set; }

    public AmountType AmountType { get; set; }

    public decimal AmountValue { get; set; }

    public DateTime EndTime { get; set; }

    public string Remarks { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
