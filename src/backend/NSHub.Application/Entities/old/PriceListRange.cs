using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class PriceListRange : BaseEntity
{

    public Guid PriceListId { get; set; }

    public DateTime Validity { get; set; }

    public DateTime EndValidity { get; set; }

    public virtual PriceList? PriceList { get; set; }
}
