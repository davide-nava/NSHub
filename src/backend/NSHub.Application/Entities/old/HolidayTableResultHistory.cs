using System;
using System.Collections.Generic;

using PlanetHub.Enums;

namespace PlanetHub.ApplicationCore.Entities;

public class HolidayTableResultHistory : BaseEntity
{
    public DateTime HistoryDate { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid HolidayTypeId { get; set; }

    public decimal Accrued { get; set; }

    public decimal Accredit { get; set; }

    public decimal Completed { get; set; }

    public decimal RemainingPast { get; set; }

    public RecordType RecordType { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual HolidayType? HolidayType { get; set; }

}
