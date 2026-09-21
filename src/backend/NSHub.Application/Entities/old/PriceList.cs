using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PriceList : BaseEntity
{
    public PriceListType PriceListType { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
