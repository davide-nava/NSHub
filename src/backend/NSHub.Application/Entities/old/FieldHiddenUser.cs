using System;
using System.Collections.Generic;

using PlanetHub.ApplicationCore.Entities;

namespace PlanetHub.ApplicationCore.Entities;

public class FieldHiddenUser : BaseEntity
{

    public Guid FieldId { get; set; }

    public string FieldName { get; set; } = null!;

    public Guid UserId { get; set; }

    public virtual Field? Field { get; set; }
    public virtual User? User { get; set; }


}
