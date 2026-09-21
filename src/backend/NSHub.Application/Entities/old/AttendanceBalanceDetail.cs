using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AttendanceBalanceDetail : BaseEntity
{
    public Guid AttendanceBalanceId { get; set; }

    public int Sign { get; set; }

    public Guid AccountId { get; set; }

    public Guid FormulaId { get; set; }

    public Guid GroupHolidayTableId { get; set; }

    public virtual AttendanceBalance? AttendanceBalance { get; set; }

    public virtual Formula? Formula { get; set; }

    public virtual Account? Account { get; set; }

    public virtual GroupHolidayTable? GroupHolidayTable { get; set; }
}
