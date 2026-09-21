using System;

using PlanetHub.ApplicationCore.Entities;
using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalarySwissdecLogDetail : BaseEntity
{
    public SalarySwissdecLogDetailDetailType SalarySwissdecLogDetailDetailType { get; set; }

    public string JobKey { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public StatusType StatusType { get; set; }

}
