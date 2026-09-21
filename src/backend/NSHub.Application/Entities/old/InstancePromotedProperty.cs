using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class InstancePromotedProperty : BaseEntity
{
    public Guid InstanceId { get; set; }

    public byte? EncodingOption { get; set; }

    public string PromotionName { get; set; } = null!;
}
