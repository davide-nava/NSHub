using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities.Json;

namespace NSHub.ApplicationCore.Entities;

public class WorkingTimeGroup : BaseEntity
{
    public Guid DescriptionId { get; set; }

    public bool IsPlanning { get; set; }

    public Guid ColorTypeId { get; set; }

    public virtual ColorType? ColorType { get; set; }

    public Guid FallbackWorkingTimeId { get; set; }

    public Guid FallbackWorkingTimeBeforeHolidayId { get; set; }

    public Guid FallbackWorkingTimeHolidayId { get; set; }

    public Guid FallbackWorkingTimeUnidentifiedHolidayId { get; set; }

    public IEnumerable<GuidListJson> FallbackWorkingTimeSpecialDays { get; set; }

    public Guid FallbackWorkingTimeSaturdayId { get; set; }

    public Guid FallbackWorkingTimeSundayId { get; set; }

    public string Code { get; set; } = null!;

    public string ExportCode { get; set; } = null!;

    public IEnumerable<GuidListJson> WorkingTimes { get; set; }

    public IEnumerable<GuidListJson> Fallbacks { get; set; }

    // TODO: commentare
    public string VisibleFor { get; set; } = null!;

    // TODO: commentare
    public string ShiftNeeds { get; set; } = null!;

    public virtual TranslationGroup? Description { get; set; }

}
