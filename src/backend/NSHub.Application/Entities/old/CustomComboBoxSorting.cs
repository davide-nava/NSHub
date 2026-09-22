using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomComboboxSorting : BaseEntity
{

    public SortModeType SortModeType { get; set; }

    public Guid FieldId { get; set; }

    public virtual Field? Field { get; set; }

}
