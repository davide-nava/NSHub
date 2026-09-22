using System;
using System.Collections.Generic;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class KleSynchronizeIncident : BaseEntity
{

    public Guid DeclareIncidentDetailId { get; set; }

    public StatusType StatusType { get; set; }

    // TODO: Check type
    public int Process { get; set; }

    // TODO: Check type
    public int Coverage { get; set; }

    // TODO: Check type
    public int DigitalizationScope { get; set; }

    public virtual DeclareIncidentDetail? DeclareIncidentDetail { get; set; }


}
