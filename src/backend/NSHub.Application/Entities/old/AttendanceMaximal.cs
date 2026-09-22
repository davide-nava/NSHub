using System;
using System.Collections.Generic;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceMaximal : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public int ProportionateEnterExit { get; set; }

    public int ConsoleTimeFormat { get; set; }

    public int PrintAndWebTimeFormat { get; set; }

    public decimal TimeFormatRound { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
