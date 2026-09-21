using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class ProcessingCycle : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid NoteId { get; set; }
    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Note { get; set; }
    public virtual TranslationGroup? Description { get; set; }

}
