using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EmployeeAttendanceJob : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public DateTime ValidFrom { get; set; }

    public Guid TimeTableId { get; set; }

    public bool WithoutNight { get; set; }

    public Guid AttendanceManagementId { get; set; }

    public decimal HourlyRate { get; set; }

    public int IgnoreMode { get; set; }

    public Guid SupervisorId { get; set; }

    public Guid AttendanceProgressiveId { get; set; }

    public Guid AttendanceRecalculationGroupId { get; set; }

    public IEnumerable<GuidList> JobLevels { get; set; }


    public int DefaultJobUseMode { get; set; }

    public Guid HolidayHeaderId { get; set; }

    public int GeolocationTimeout { get; set; }

    public Guid HolidayTableGroupId { get; set; }

    public Guid AttendanceAgreementId { get; set; }

    public Guid TimeSheetPrintGroupId { get; set; }

    public int HolidayTableDailyDivider { get; set; }

    public Guid DefaultDelegateId { get; set; }

    public bool IsOutOfOffice { get; set; }

    public int StartScrolling { get; set; }

    public Guid FormulaCanteenDataId { get; set; }

    public string ShiftNeeds { get; set; } = null!;

    public string AuthorizedEquipments { get; set; } = null!;

    public GeolocationMandatoryModeType GeolocationMandatoryModeType { get; set; }

}
