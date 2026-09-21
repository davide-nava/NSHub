using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AccountingPeriod : BaseEntity
{
    public DateTime StartDate { get; set; }

    public DateTime EndDate { get; set; }

    public DateTime ClosingDate { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
