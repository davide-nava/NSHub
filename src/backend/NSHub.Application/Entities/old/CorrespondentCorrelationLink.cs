using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CorrespondentCorrelationLink : BaseEntity
{

    public Guid CorrelationId { get; set; }

    public Guid CorrelationInverseId { get; set; }

    public virtual Correlation? Correlation { get; set; }
    public virtual CorrelationInverse? CorrelationInverse { get; set; }


}
