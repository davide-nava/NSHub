using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class FieldMailMerge : BaseEntity
{

    public Guid FieldId { get; set; }

    public string InternalCode { get; set; }

    public string InternalCodeTable { get; set; } = null!;

    public virtual Field? Field { get; set; }
}
