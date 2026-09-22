using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities.Json;

namespace NSHub.ApplicationCore.Entities;

public class TimeZone : BaseEntity
{
    public Guid AccountId { get; set; }

    public Guid DescriptionId { get; set; }

    public string Code { get; set; } = null!;

    public Guid ColorTypeId { get; set; }

    public virtual ColorType? ColorType { get; set; }

    public bool IsRegularWorkingZone { get; set; }

    public bool UseAsPause { get; set; }

    public Guid TimeZoneTypeId { get; set; }

    public virtual TimeZoneType? TimeZoneType { get; set; }

    public Guid RoundingId { get; set; }

    public Guid RoundingDailyId { get; set; }

    public Guid SecondaryAccountId { get; set; }

    // TODO: Check type
    public int JobComputing { get; set; }

    // TODO: Check type
    public int JobRoundingValue { get; set; }

    // TODO: Check type
    public int JobRebateValue { get; set; }

    public Guid RoundingPauseId { get; set; }

    public Guid RoundingDailyPauseId { get; set; }

    public Guid RoundingServiceId { get; set; }

    public Guid RoundingDailyServiceId { get; set; }

    public bool IgnoreZoneRange { get; set; }

    public bool IsRoundSecondaryAccount { get; set; }

    public Guid AccountWorkingDayId { get; set; }

    public Guid AccountBeforeHolidayId { get; set; }

    public Guid AccountHolidayId { get; set; }

    public Guid AccountUnidentifiedHolidayId { get; set; }

    public IEnumerable<GuidListJson> AccountSpecialDays { get; set; }

    public Guid AccountSaturdayId { get; set; }

    public Guid AccountSundayId { get; set; }

    public Guid SecondaryAccountWorkingDayId { get; set; }

    public Guid SecondaryAccountBeforeHolidayId { get; set; }

    public Guid SecondaryAccountHolidayId { get; set; }

    public Guid SecondaryAccountUnidentifiedHolidayId { get; set; }

    public IEnumerable<GuidListJson> SecondaryAccountSpecialDays { get; set; }

    public Guid SecondaryAccountSaturdayId { get; set; }

    public Guid SecondaryAccountSundayId { get; set; }

    public Guid AccountOnEnterId { get; set; }

    public Guid AccountOnExitId { get; set; }

    public Guid AccountOnEnterWorkingDayId { get; set; }

    public Guid AccountOnEnterBeforeHolidayId { get; set; }

    public Guid AccountOnEnterHolidayId { get; set; }

    public Guid AccountOnEnterUnidentifiedHolidayId { get; set; }

    public IEnumerable<GuidListJson> AccountOnEnterSpecialDays { get; set; }

    public Guid AccountOnEnterSaturdayId { get; set; }

    public Guid AccountOnEnterSundayId { get; set; }

    public Guid AccountOnExitWorkingDayId { get; set; }

    public Guid AccountOnExitBeforeHolidayId { get; set; }

    public Guid AccountOnExitHolidayId { get; set; }

    public Guid AccountOnExitUnidentifiedHolidayId { get; set; }

    public IEnumerable<GuidListJson> AccountOnExitSpecialDays { get; set; }

    public Guid AccountOnExitSaturdayId { get; set; }

    public Guid AccountOnExitSundayId { get; set; }

    public bool IsClockingToAuthorize { get; set; }

    public int EnterTolerance { get; set; }

    public int ExitTolerance { get; set; }

    public bool IgnorePauseTimeOnSecondaryAccount { get; set; }

    public bool CoversNeed { get; set; }

    public Guid RoundingTimeZoneByEventId { get; set; }


    public virtual TranslationGroup? Description { get; set; }
    public virtual Rounding? RoundingTimeZoneByEvent { get; set; }
    public virtual Account? Account { get; set; }

    public virtual Rounding? Rounding { get; set; }
    public virtual Rounding? RoundingDaily { get; set; }
    public virtual Account? SecondaryAccount { get; set; }

    public virtual Rounding? RoundingPause { get; set; }
    public virtual Rounding? RoundingDailyPause { get; set; }
    public virtual Rounding? RoundingService { get; set; }
    public virtual Rounding? RoundingDailyService { get; set; }

    public virtual Account? AccountWorkingDay { get; set; }
    public virtual Account? AccountBeforeHoliday { get; set; }
    public virtual Account? AccountHoliday { get; set; }
    public virtual Account? AccountUnidentifiedHoliday { get; set; }
    public virtual Account? AccountSaturday { get; set; }

    public virtual Account? AccountSunday { get; set; }
    public virtual Account? SecondaryAccountWorkingDay { get; set; }
    public virtual Account? SecondaryAccountBeforeHoliday { get; set; }

    public virtual Account? SecondaryAccountHoliday { get; set; }
    public virtual Account? SecondaryAccountUnidentifiedHoliday { get; set; }
    public virtual Account? SecondaryAccountSaturday { get; set; }
    public virtual Account? SecondaryAccountSunday { get; set; }
    public virtual Account? AccountOnEnter { get; set; }
    public virtual Account? AccountOnExit { get; set; }
    public virtual Account? AccountOnEnterWorkingDay { get; set; }
    public virtual Account? AccountOnEnterBeforeHoliday { get; set; }

    public virtual Account? AccountOnEnterHoliday { get; set; }
    public virtual Account? AccountOnEnterUnidentifiedHoliday { get; set; }
    public virtual Account? AccountOnEnterSaturday { get; set; }
    public virtual Account? AccountOnEnterSunday { get; set; }
    public virtual Account? AccountOnExitWorkingDay { get; set; }
    public virtual Account? AccountOnExitBeforeHoliday { get; set; }
    public virtual Account? AccountOnExitHoliday { get; set; }
    public virtual Account? AccountOnExitUnidentifiedHoliday { get; set; }
    public virtual Account? AccountOnExitSaturday { get; set; }
    public virtual Account? AccountOnExitSunday { get; set; }
}
