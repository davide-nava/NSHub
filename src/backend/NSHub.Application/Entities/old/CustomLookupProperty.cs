using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CustomLookupProperty : BaseEntity
{
    public int CustomLookupPropertiesId { get; set; }


    public int CustomLookupPropertiesIdField { get; set; }

    public Guid CustomLookupPropertiesUid { get; set; }

    public Guid DescriptionId { get; set; }
    public Guid FieldId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


    public virtual Field? Field { get; set; }
}
