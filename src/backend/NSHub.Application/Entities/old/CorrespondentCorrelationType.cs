using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class CorrespondentCorrelationType : BaseEntity
{
    public int IdGroup { get; set; }

    public string MailMergePrefix { get; set; } = null!;

    public MedidataPayantType MedidataPayantType { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Group? Group { get; set; }


}
