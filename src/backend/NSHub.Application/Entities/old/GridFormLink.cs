using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class GridFormLink : BaseEntity
{

    public string CodeGrid { get; set; } = null!;

    public string FormUniqueId { get; set; } = null!;

    public Guid FieldId { get; set; }

    public string CodeAppModule { get; set; } = null!;

    public string CodeAppSection { get; set; } = null!;


    public virtual Field? Field { get; set; }

}
