using System;
using System.Collections;

namespace PlanetHub.ApplicationCore.Entities;

public class District : BaseEntity
{
    public DateTime From { get; set; }

    public DateTime To { get; set; }

    public string Code { get; set; } = null!;

    public Guid CantonTypeId { get; set; }

    public Guid CountryTypeId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual CantonType? CantonType { get; set; }
    public virtual CountryType? CountryType { get; set; }

}
