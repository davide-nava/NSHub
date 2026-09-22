using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class HolidayTableGroupBody : BaseEntity
{

    public Guid HolidayTableGroupId { get; set; }

    public Guid HolidayTableId { get; set; }

    public Guid ConsoleTimeFormatId { get; set; }

    public Guid PrintAndWebTimeFormatId { get; set; }

    public decimal TimeFormatRound { get; set; }

    public virtual HolidayTableGroup? HolidayTableGroup { get; set; }
    public virtual HolidayTable? HolidayTable { get; set; }

}
