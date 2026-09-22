using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class FieldTranscode : BaseEntity
{

    public string Grid { get; set; } = null!;

    public string ValueItem { get; set; } = null!;

    public string Other { get; set; } = null!;

    public Guid FieldId { get; set; }

    public bool Locked { get; set; }

    public string EnumType { get; set; } = null!;

    public string AdvancedQuery { get; set; } = null!;

    public ValueItemType ValueItemType { get; set; }

    public bool IsVerifyInUseWhenDeleting { get; set; }

    public virtual Field? Field { get; set; }


}
