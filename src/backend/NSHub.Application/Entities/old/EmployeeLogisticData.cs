using System;
using System.Collections.Generic;

namespace PlanetHub.ApplicationCore.Entities;

public class EmployeeLogisticData : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public DateTime ValidFrom { get; set; }

    public int LogDataBase { get; set; }

    public int LogDataCompany { get; set; }

    public int LogDataDivision { get; set; }

    public int LogDataFunction { get; set; }

    public int LogDataJobGroup { get; set; }

    public int LogDataLevel { get; set; }

    public int LogDataQualification { get; set; }

    public int LogDataBelongingCenter { get; set; }

    public int LogDataCostCenter { get; set; }

    public string ReferenceHr { get; set; }

    public virtual Employee? Employee { get; set; }
}
