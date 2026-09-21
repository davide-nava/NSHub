using System;

using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class VatPeriod : BaseEntity
{
    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public Guid ComputationTypeId { get; set; }

    public virtual ComputationType? ComputationType { get; set; }

    public DateTime ClosingDate { get; set; }

    public decimal BalanceRate { get; set; }

    public bool IsCorrection { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
