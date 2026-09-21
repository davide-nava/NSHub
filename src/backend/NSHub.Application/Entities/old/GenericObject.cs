using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class GenericObject : BaseEntity
{
    public string RegistrationNumber { get; set; } = null!;

    public Guid BrandId { get; set; }

    public Guid ModelId { get; set; }

    public string Opb { get; set; } = null!;

    public decimal Counter { get; set; }

    public DateTime EnterDate { get; set; }

    public DateTime RegistrationDate { get; set; }

    public IEnumerable<TranslationGroupList> Features { get; set; }

    public IEnumerable<DateTimeGroupList> Dates { get; set; }
    public IEnumerable<IntGroupList> Numbers { get; set; }

    public IEnumerable<TranslationGroupList> Texts { get; set; }


    public string Notes { get; set; } = null!;


    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
