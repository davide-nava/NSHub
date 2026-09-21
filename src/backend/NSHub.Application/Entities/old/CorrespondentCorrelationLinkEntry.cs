using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Bibliography;

namespace PlanetHub.ApplicationCore.Entities;

public class CorrespondentCorrelationLinkEntry : BaseEntity
{
    public Guid SourceId { get; set; }

    public Guid RelatedId { get; set; }

    public Guid CorrelationId { get; set; }

    public virtual Source? Source { get; set; }
    public virtual Related? Related { get; set; }
    public virtual Correlation? Correlation { get; set; }

}
