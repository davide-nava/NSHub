using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class ProductionPhase : BaseEntity
{
    public Guid ProductionOrderId { get; set; }

    public Guid ProcessingPhaseId { get; set; }

    public DateTime DateCalculatedEnd { get; set; }

    public DateTime DateEnd { get; set; }

    public virtual ProductionOrder? ProductionOrder { get; set; }
    public virtual ProcessingPhase? ProcessingPhase { get; set; }

}
