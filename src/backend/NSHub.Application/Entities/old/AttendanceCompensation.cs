using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceCompensation : BaseEntity
{
    public Guid DescriptionId { get; set; }

    public AbsenceType AbsenceType { get; set; }

    public int Absence { get; set; }

    public ExceedType ExceedType { get; set; }

    public int Exceed { get; set; }

    public int AbsenceRecoveded { get; set; }

    public int AbsenceRecovery { get; set; }

    public bool OrdinaryModify { get; set; }

    public PeriodModeType PeriodModeType { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
