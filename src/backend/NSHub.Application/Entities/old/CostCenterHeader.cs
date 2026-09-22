using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CostCenterHeader : BaseEntity
{
    public Guid RecordId { get; set; }

    public string FieldName { get; set; } = null!;

}
