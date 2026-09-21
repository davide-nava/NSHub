using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class BorderTown : BaseEntity
{
    public string PostalCode { get; set; } = null!;

    public bool IsBorderTown { get; set; }

    public bool IsABorderTown { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
