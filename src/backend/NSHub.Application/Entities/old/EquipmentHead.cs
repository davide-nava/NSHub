using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class EquipmentHead : BaseEntity
{
    public Guid EquipmentDetailId { get; set; }

    public string Code { get; set; } = null!;

    public TransitType TransitType { get; set; }

    public int LogDataBase { get; set; }

    public int LogDataCompany { get; set; }

    public int LogDataDivision { get; set; }

    public int LogDataFunction { get; set; }

    public int LogDataJobGroup { get; set; }

    public int LogDataLevel { get; set; }

    public int LogDataQualification { get; set; }

    public int LogDataBelongingCenter { get; set; }

    public int LogDataCostCenter { get; set; }

    public int Position { get; set; }

    public string Command { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual EquipmentDetail? EquipmentDetail { get; set; }
}
