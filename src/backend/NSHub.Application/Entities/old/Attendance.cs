using System;
using System.Collections.Generic;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class Attendance : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public DateTime Date { get; set; }

    public int LogDataBase { get; set; }

    public int LogDataCompany { get; set; }

    public int LogDataDivision { get; set; }

    public int LogDataFunction { get; set; }

    public int LogDataJobGroup { get; set; }

    public int LogDataLevel { get; set; }

    public int LogDataQualification { get; set; }

    public int TotalAttendanceMinutes { get; set; }

    public int TotalMinutes { get; set; }

    public bool ComputeOrdinaryJob { get; set; }

    public decimal HourlyRate { get; set; }

    public Guid TimeTableId { get; set; }

    public Guid WorkingTimeId { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual TimeTable? TimeTable { get; set; }
    public virtual WorkingTime? WorkingTime { get; set; }

    public int LogDataBelongingCenter { get; set; }

    public bool HasUserModifiedClockings { get; set; }

    public int LogDataCostCenter { get; set; }

    public DayStateType DayStateType { get; set; }

    public ComputationStateType ComputationStateType { get; set; }

    public bool HasUserModifiedWorkingTime { get; set; }

    public bool HasUserModifiedTimetable { get; set; }

    public Guid NoteId { get; set; }

    public virtual TranslationGroup? Note { get; set; }

    public Guid ScrollingTimeTableId { get; set; }

    public bool IsScrollingTimeTableChanged { get; set; }

    public Guid WorkingTimeGroupId { get; set; }

    public bool HasUserModifiedWorkingTimeGroup { get; set; }

    public int TimeContinued { get; set; }

    public bool HasUserModifiedJustification { get; set; }

    public decimal DailyDivider { get; set; }

    public bool HasUserModifiedDailyDivider { get; set; }

    public bool IgnoreNightRange { get; set; }

    public bool ForceComputationByDate { get; set; }


    public Guid DescriptionAdditionalNoteId { get; set; }

    public virtual TranslationGroup? DescriptionAdditionalNote { get; set; }

}
