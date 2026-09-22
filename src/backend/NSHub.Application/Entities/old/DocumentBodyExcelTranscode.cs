using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class DocumentBodyExcelTranscode : BaseEntity
{
    public string PlanetField { get; set; } = null!;

    public Guid FieldId { get; set; }

    public virtual Field? Field { get; set; }
}
