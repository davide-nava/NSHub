using System;
using System.Collections.Generic;

namespace NSHub.ApplicationCore.Entities;

public class EmployeeOnJobEntry : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public IEnumerable<GuidList> JobEntries { get; set; }


    public DateTime DateStart { get; set; }

    public DateTime DateEnd { get; set; }

    public string Contract { get; set; } = null!;

    public string NoticeText { get; set; } = null!;

    public Guid TimeTableId { get; set; }

    public string CompanyPart { get; set; } = null!;

    public string IscoCode { get; set; } = null!;

    public string IndividualJobTitle { get; set; } = null!;

    public string ContractualJobTitle { get; set; } = null!;

    public Guid WorkplaceAgencyId { get; set; }

    public Guid KindOfWagePaymentId { get; set; }

    public bool IsAdministrativeEmployee { get; set; }


    public virtual TimeTable? TimeTable { get; set; }
    public virtual WorkplaceAgency? WorkplaceAgency { get; set; }
    public virtual KindOfWagePayment? KindOfWagePayment { get; set; }

}
