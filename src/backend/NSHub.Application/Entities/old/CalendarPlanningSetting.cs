using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class CalendarPlanningSetting : BaseEntity
{

    public string CodeUser { get; set; } = null!;

    public bool IsVisibleForAllUsers { get; set; }

    public string Xml { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
