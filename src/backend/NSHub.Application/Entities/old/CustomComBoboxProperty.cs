using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomComboboxProperty
{
    public string Value { get; set; } = null!;

    public Guid FieldId { get; set; }

    public virtual Field? Field { get; set; }

}
