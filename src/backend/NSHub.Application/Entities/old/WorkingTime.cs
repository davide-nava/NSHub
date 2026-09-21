using System;

namespace PlanetHub.ApplicationCore.Entities;

public class WorkingTime : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public int AttendanceMinutes { get; set; }

    public Guid AccountPositiveDiffId { get; set; }

    public Guid AccountNegativeDiffId { get; set; }

    public virtual Account? AccountNegativeDiff { get; set; }

    public virtual Account? AccountPositiveDiff { get; set; }

    public Guid ColorTypeId { get; set; }

    public virtual ColorType? ColorType { get; set; }

    public Guid AttendanceRecalculationGroupId { get; set; }

    public virtual AttendanceRecalculationGroup? AttendanceRecalculationGroup { get; set; }

    public int AbsenceMinutes { get; set; }

    public int AbsenceCalculation { get; set; }

    public bool AttendanceContractAverage { get; set; }

    public bool AbsenceContractAverage { get; set; }

    public string Pauses { get; set; } = null!;

    public bool IsPlanning { get; set; }

    public Guid WorkingTimePauseValueId { get; set; }

    public virtual WorkingTime? WorkingTimePauseValue { get; set; }

    public bool EnableForNightComputing { get; set; }

    public string ExportCode { get; set; } = null!;

    public decimal AttendancePercentage { get; set; }

    public decimal AbsencePercentage { get; set; }

    // TODO: commentare
    public string VisibleFor { get; set; } = null!;

    public int AdditionalExpectedMinutes { get; set; }

    // TODO: commentare
    public string ShiftNeeds { get; set; } = null!;

    public Guid ConditionalAccountAccountId { get; set; }

    public virtual Account? ConditionalAccount { get; set; }

    // TODO: Check type
    public int ConditionalAccountCheckTime { get; set; }

    public decimal ConditionalAccountValueForTimesheet { get; set; }

    public string ConditionalAccountControlSum { get; set; } = null!;

    // TODO: Check type
    public int ConditionalAccountStepComputing { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
