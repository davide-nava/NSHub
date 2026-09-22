using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Math;

namespace NSHub.ApplicationCore.Entities;

public class JobLevel : BaseEntity
{
    public int Level { get; set; }

    public bool Inactive { get; set; }

    public bool ClockingNotExisting { get; set; }

    public Guid NumeratorId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual Numerator? Numerator { get; set; }

}
