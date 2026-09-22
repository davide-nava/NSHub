using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class HolidayTable : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid HolidayTypeId { get; set; }

    public CalendarType CalendarType { get; set; }

    public int StartMonth { get; set; }

    public string AccountGroupIds { get; set; } = null!;

    public string CategoryForExpectedAdditionIds { get; set; } = null!;

    public PreviousBalanceModeType PreviousBalanceModeType { get; set; }


    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }
    public virtual HolidayType? HolidayType { get; set; }


}
