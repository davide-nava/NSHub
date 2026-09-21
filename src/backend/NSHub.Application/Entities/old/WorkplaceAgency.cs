using System;

namespace PlanetHub.ApplicationCore.Entities;

public class WorkplaceAgency : BaseEntity
{
    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public Guid? DistrictId { get; set; }

    public virtual District? RegionType { get; set; }

    // TODO: commentare
    public string Branch { get; set; } = null!;

    // TODO: commentare
    public string Team { get; set; } = null!;

}
