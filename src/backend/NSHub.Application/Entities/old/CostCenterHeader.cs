using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CostCenterHeader : BaseEntity
{
    public Guid RecordId { get; set; }

    public string FieldName { get; set; } = null!;

}
