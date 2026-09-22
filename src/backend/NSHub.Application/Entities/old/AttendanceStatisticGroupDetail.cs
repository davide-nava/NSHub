using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class AttendanceStatisticGroupDetail : BaseEntity
{
    public int Position { get; set; }

    public Guid AttendanceStatisticId { get; set; }

    public Guid AttendanceStatisticGroupId { get; set; }

    public bool Visible { get; set; }

    public int OrderBy { get; set; }

    public TotalType TotalType { get; set; }

    public bool EnableForTotal { get; set; }

    public ColorType ColorType { get; set; }

    public bool SplitOnHistory { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

    public virtual AttendanceStatisticGroup? AttendanceStatisticGroup { get; set; }

    public virtual AttendanceStatistic? AttendanceStatistic { get; set; }
}
