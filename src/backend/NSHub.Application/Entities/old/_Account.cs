using System.Collections.Generic;

using NSHub.ApplicationCore.Entities;
using NSHub.ApplicationCore.Entities.Json;

namespace NSHub.ApplicationCore.Entities;

public class Account : BaseEntity
{
    public string Code { get; set; } = null!;

    public bool IsOrdinaryJob { get; set; }

    public bool IsHoliday { get; set; }

    public bool IsBeforeHoliday { get; set; }

    public string ReferenceHr { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public Guid DescriptionLongId { get; set; }

    public Guid NumericTypeId { get; set; }

    public virtual NumericType NumericType { get; set; }

    public string SalaryExportCondition { get; set; } = null!;

    public bool Reset { get; set; }

    public Guid AccountPriorityTypeId { get; set; }

    public virtual AccountPriorityType AccountPriorityType { get; set; }

    public Guid ColorTypeId { get; set; }

    public virtual ColorType ColorType { get; set; }

    public string Davers { get; set; } = null!;

    public Guid AccountRoundingTypeId { get; set; }

    public virtual AccountRoundingType AccountRoundingType { get; set; }

    public bool Additional { get; set; }

    public bool DoNotPrint { get; set; }

    public bool AddToEquipmentList { get; set; }

    public int EquipmentListPosition { get; set; }

    public bool IsUnidentifiedHoliday { get; set; }

    public IEnumerable<BoolListJson> IsSpecialDays { get; set; }

    public int UseMinutesMode { get; set; }

    public decimal Percentage { get; set; }

    public int AbsenceCalculation { get; set; }

    public bool IsHolidayNotWorking { get; set; }

    public bool IsBeforeHolidayNotWorking { get; set; }

    public bool IsUnidentifiedHolidayNotWorking { get; set; }

    public IEnumerable<BoolListJson> IsSpecialDayNotWorkings { get; set; }

    public Guid HolidayNotWorkingTypeId { get; set; }

    public Guid BeforeHolidayNotWorkingTypeId { get; set; }

    public Guid UnidentifiedHolidayNotWorkingTypeId { get; set; }

    public virtual HolidayNotWorkingType HolidayNotWorkingType { get; set; }

    public virtual BeforeHolidayNotWorkingType BeforeHolidayNotWorkingType { get; set; }

    public virtual UnidentifiedHolidayNotWorkingType UnidentifiedHolidayNotWorkingType { get; set; }

    public IEnumerable<GuidListJson> SpecialDayNotWorkingTypes { get; set; }

    public bool ApplyContractualAverage { get; set; }

    public bool AllDayAbsence { get; set; }

    public bool WebJustification { get; set; }

    public bool ExcludeZoneRangeTime { get; set; }

    public bool Saturday { get; set; }

    public bool Sunday { get; set; }

    public bool AttendanceNotExpected { get; set; }

    public bool CheckOnSchedule { get; set; }

    public bool IsOvertimeAuthorizable { get; set; }

    public Guid OvertimeAuthorizedId { get; set; }

    public Guid OvertimeNotAuthorizedId { get; set; }

    public int OvertimeAuthorizePriority { get; set; }

    public bool AbsenceUe { get; set; }

    public int ApplyFunction { get; set; }

    public int VisibleInAbsencePlan { get; set; }

    public Guid NotWorkingDayId { get; set; }

    public bool Plannable { get; set; }

    public bool IsPriorityOnOrdinary { get; set; }

    public int Excess { get; set; }

    public bool UseOvertime { get; set; }

    public bool ConvertRequestPeriodToQuantity { get; set; }

    public int Tolerance { get; set; }

    public string ExportCode { get; set; } = null!;

    public bool WithoutClockingOrdinaryComp { get; set; }

    public string VisibleFor { get; set; } = null!;

    public string ReferenceNt { get; set; } = null!;

    public bool WriteAbsent { get; set; }

    public bool ReloadValueFromRequest { get; set; }

    public string RoundingEntryPoint { get; set; } = null!;

    public Guid OvertimeAlternativeId { get; set; }

    public bool AutoCreateOvertime { get; set; }

    public bool IsHideWebTimeSheet { get; set; }

    public Guid FeedingTimeId { get; set; }


    public bool AlwaysAuthorized { get; set; }

    public IEnumerable<GuidList> JobLevels { get; set; }

    public bool AbsenceWarning { get; set; }

    public int AbsenceWarningTolerance { get; set; }

    public string AvailableFor { get; set; } = null!;

    public bool ExcludeFromNeeds { get; set; }

    public virtual GroupAccount? GroupAccount { get; set; }



    public virtual TranslationGroup? Description { get; set; }

    public virtual TranslationGroup? DescriptionLong { get; set; }


}
