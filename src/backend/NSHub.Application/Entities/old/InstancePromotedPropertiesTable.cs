using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class InstancePromotedPropertiesTable : BaseEntity
{
    public Guid SurrogateInstanceId { get; set; }

    public string PromotionName { get; set; } = null!;

}
