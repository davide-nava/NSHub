using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class InstancePromotedPropertyValue : BaseEntity
{
    public Guid InstancePromotedPropertyId { get; set; }

    public object? Value { get; set; }

    public virtual InstancePromotedProperty? InstancePromotedProperty { get; set; }

}
