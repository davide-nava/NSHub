using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class LogisticData : BaseEntity
{
    public string ReferenceHr { get; set; }

    public LogisticDataType LogisticDataType { get; set; }

    public string Code { get; set; } = null!;

    public string RefExternal { get; set; } = null!;

    public decimal Latitude { get; set; }

    public decimal Longitude { get; set; }

    public int LocationTolerance { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
