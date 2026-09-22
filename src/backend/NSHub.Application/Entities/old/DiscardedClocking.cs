using System;
using System.Collections.Generic;

using DocumentFormat.OpenXml.Bibliography;

namespace NSHub.ApplicationCore.Entities;

public class DiscardedClocking : BaseEntity
{
    public string RawClocking { get; set; } = null!;

    public Guid ClockingKindId { get; set; }

    public DateTime ImportDateTime { get; set; }

    public int EquipmentNumber { get; set; }

    public int EquipmentDetailsNumber { get; set; }

    public Guid EquipmentTypeId { get; set; }

    public string SourceDetails { get; set; } = null!;

    public Guid SourceId { get; set; }

    public virtual ClockingKind? ClockingKind { get; set; }
    public virtual EquipmentType? EquipmentType { get; set; }
    public virtual Source? Source { get; set; }
    public virtual Account? Account { get; set; }

    public string BadgeNumber { get; set; } = null!;

    public DateTime DateAndTime { get; set; }

    public Guid AccountId { get; set; }

    public int LogDataBase { get; set; }

    public int LogDataCompany { get; set; }

    public int LogDataDivision { get; set; }

    public int LogDataFunction { get; set; }

    public int LogDataJobGroup { get; set; }

    public int LogDataLevel { get; set; }

    public int LogDataQualification { get; set; }

    public int LogDataBelongingCenter { get; set; }

    public int LogDataCostCenter { get; set; }

}
