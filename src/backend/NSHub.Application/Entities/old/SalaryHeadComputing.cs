using System;
using System.Collections.Generic;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryHeadComputing : BaseEntity
{
    public int ComputingYear { get; set; }

    public int ComputingYearCompetence { get; set; }

    public bool IsClosed { get; set; }

    public DateTime ComputingDate { get; set; }

    public DateTime ValueDate { get; set; }

    public Guid EmployeeId { get; set; }

    public Guid GroupSalaryId { get; set; }

    public virtual Employee? Employee { get; set; }
    public virtual GroupSalary? GroupSalary { get; set; }

    public int ComputingMonth { get; set; }

    public ComputingType ComputingType { get; set; }

    public Guid EmployeeEnterExitId { get; set; }

    public bool AnnualSalary { get; set; }

    public string SoftwareVersion { get; set; } = null!;

    public virtual EmployeeEnterExit? EmployeeEnterExit { get; set; }
    public virtual LogisticData? LogisticData { get; set; }

    public Guid LogisticDataId { get; set; }

    public string ThirteenthCode { get; set; }

    public Guid CostCenterId { get; set; }

    public Guid SalaryAccountingHeaderId { get; set; }

    public virtual CostCenter? CostCenter { get; set; }
    public virtual SalaryAccountingHeader? SalaryAccountingHeader { get; set; }


    public SalaryType SalaryType { get; set; }

    public bool IsPaymentAfterExitCompetence { get; set; }

    public bool IsTechnical { get; set; }

    public string PrintDetail { get; set; } = null!;

    public bool IsTariTemp { get; set; }

}
