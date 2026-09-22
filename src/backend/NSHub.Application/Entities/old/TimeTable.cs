using System;
using System.Collections.Generic;

using NSHub.ApplicationCore.Entities.Json;

namespace NSHub.ApplicationCore.Entities;

public class TimeTable : BaseEntity
{
    public string Code { get; set; } = null!;

    public bool BeforeHoliday { get; set; }

    public Guid DescriptionId { get; set; }

    public DateTime EndNight { get; set; }

    public bool NightEnabled { get; set; }

    public bool Holiday { get; set; }

    public DateTime InLimit { get; set; }

    public IEnumerable<BoolListJson> Days { get; set; }

    public Guid TotalTypeId { get; set; }

    public virtual TotalType? TotalType { get; set; }

    public int TotalMin { get; set; }

    public int TotalMax { get; set; }

    public string Davers { get; set; } = null!;

    public string WorkingTimeSelectionCriteria { get; set; } = null!;

    public Guid AttendanceRecalculationGroupId { get; set; }

    public bool UnidentifiedHoliday { get; set; }

    public IEnumerable<IntListJson> SpecialDays { get; set; }

    public IEnumerable<GuidListJson> WorkingTimeGroups { get; set; }

    public Guid NightComputingModeTypeId { get; set; }

    public virtual NightComputingModeType? NightComputingModeType { get; set; }

    public bool IgnoreNotEvenPauseClocking { get; set; }

    // TODO: Check type
    public int ExitEnterNightRange { get; set; }


    public virtual TranslationGroup? Description { get; set; }

    public virtual AttendanceRecalculationGroup? AttendanceRecalculationGroup { get; set; }

}
