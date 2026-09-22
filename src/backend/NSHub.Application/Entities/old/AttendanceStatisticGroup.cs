using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities;
using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceStatisticGroup : BaseEntity
{
    public string Code { get; set; } = null!;

    public GroupTimeType GroupTimeType { get; set; }

    public int LogisticDataManager { get; set; }

    public bool ShowDateFrom { get; set; }

    public bool ShowDateTo { get; set; }

    public string ShowPeriod { get; set; } = null!;

    public bool OmitDetails { get; set; }

    public int EnterExitDataManager { get; set; }

    public int AttendanceJobDataManager { get; set; }

    public int ShowTotalGeneral { get; set; }

    public int AnnualFolder { get; set; }

    public string Users { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
