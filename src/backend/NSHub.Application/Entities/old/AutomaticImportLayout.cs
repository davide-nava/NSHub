using System;
using System.Collections.Generic;

using MimeKit;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AutomaticImportLayout : BaseEntity
{
    public bool IsGeneric { get; set; }

    public Guid TableId { get; set; }

    public Guid RecordId { get; set; }

    public PriorityType PriorityType { get; set; }

    public Guid HeaderId { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Table? Table { get; set; }
    public virtual Record? Record { get; set; }
    public virtual Header? Header { get; set; }


    public virtual AutomaticImportHeader? AutomaticImportHeader { get; set; }

}
