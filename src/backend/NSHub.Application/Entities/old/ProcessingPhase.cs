using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class ProcessingPhase : BaseEntity
{

    public Guid ProcessingCycleId { get; set; }

    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public IEnumerable<TranslationGroupList> Notes { get; set; }
    public virtual TranslationGroup? Description { get; set; }
    public virtual ProcessingCycle? ProcessingCycle { get; set; }
}
