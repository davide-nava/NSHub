using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class ClockingLogisticData : BaseEntity
{
    public Guid ClockingId { get; set; }

    public int LogDataBase { get; set; }

    public int LogDataCompany { get; set; }

    public int LogDataDivision { get; set; }

    public int LogDataFunction { get; set; }

    public int LogDataJobGroup { get; set; }

    public int LogDataLevel { get; set; }

    public int LogDataQualification { get; set; }

    public int LogDataBelongingCenter { get; set; }

    public int LogDataCostCenter { get; set; }

    public virtual Clocking? Clocking { get; set; }

}
