using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities;

namespace NSHub.ApplicationCore.Entities;

public class FieldHiddenUser : BaseEntity
{

    public Guid FieldId { get; set; }

    public string FieldName { get; set; } = null!;

    public Guid UserId { get; set; }

    public virtual Field? Field { get; set; }
    public virtual User? User { get; set; }


}
