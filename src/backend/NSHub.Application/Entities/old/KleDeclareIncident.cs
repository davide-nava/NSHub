using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class KleDeclareIncident : BaseEntity
{

    public DateTime CreationDate { get; set; }

    public bool TestCase { get; set; }

    public StatusType StatusType { get; set; }

    public DeclarationModeType DeclarationModeType { get; set; }

    public Guid DescriptionMessageId { get; set; }

    public virtual TranslationGroup? DescriptionMessage { get; set; }

    public Guid DescriptionWarningId { get; set; }
    public virtual TranslationGroup? DescriptionWarning { get; set; }

    public Guid DescriptionInfoId { get; set; }

    public virtual TranslationGroup? DescriptionInfo { get; set; }
    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
