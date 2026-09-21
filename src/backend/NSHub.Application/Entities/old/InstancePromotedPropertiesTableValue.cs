using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class InstancePromotedPropertiesTableValue : BaseEntity
{
    public Guid InstancePromotedPropertiesTableId { get; set; }

    public object? Value { get; set; }

    public virtual InstancePromotedPropertiesTable? InstancePromotedPropertiesTable { get; set; }

}
