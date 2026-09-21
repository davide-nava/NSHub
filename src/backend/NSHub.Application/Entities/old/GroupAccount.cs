using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class GroupAccount : BaseEntity
{

    public string Code { get; set; } = null!;

    public Guid ClassAccountId { get; set; }

    public string Davers { get; set; } = null!;

    public Guid Category { get; set; }

    public bool IsAbsence { get; set; }


    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }


    public virtual ClassAccount? ClassAccount { get; set; }

}
