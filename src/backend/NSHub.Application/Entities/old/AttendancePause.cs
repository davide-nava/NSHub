using System;

using NSHub.ApplicationCore.Entities;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendancePause : BaseEntity
{
    public Guid DescriptionId { get; set; }

    public DateTime TimeFrom { get; set; }

    public DateTime TimeTo { get; set; }

    public bool EndDay { get; set; }

    public Guid AccountId { get; set; }

    public bool IsClockingMandatory { get; set; }

    public bool IsConvertClocking { get; set; }

    public bool IsCheckPause { get; set; }

    public Guid AccountNotWorkedId { get; set; }

    public bool UseRoundingAndRebate { get; set; }

    public int QuantityMax { get; set; }

    public bool UseForJob { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual Account? Account { get; set; }
    public virtual AccountNotWorked? AccountNotWorked { get; set; }

}
