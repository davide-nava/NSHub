using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class ClassAccount : BaseEntity
{
    public string Code { get; set; } = null!;

    public int Sign { get; set; }

    public string Davers { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
}
