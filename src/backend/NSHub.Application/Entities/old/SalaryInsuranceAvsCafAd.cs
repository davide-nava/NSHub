using System;

using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryInsuranceAvsCafAd : BaseEntity
{
    public Guid InsuranceNameId { get; set; }

    public DateTime ValidFrom { get; set; }

    public string CustomerNumber { get; set; } = null!;

    public string BranchNumber { get; set; } = null!;

    public decimal AvsAdministrativeExpense { get; set; }

    public decimal AvsEmployeeContribution { get; set; }

    public decimal AvsEmployerContribution { get; set; }

    public IEnumerable<DecimalList> AdEmployeeContributions { get; set; }
    public IEnumerable<DecimalList> AdEMaxAnnualSalaries { get; set; }
    public IEnumerable<DecimalList> AdEmployerContributions { get; set; }


    public decimal CafCantonalContribution { get; set; }

    public decimal CafChildAllowance { get; set; }

    public decimal CafStudyAllowance { get; set; }

    public string CafCantons { get; set; } = null!;

    public decimal SpecialCaseFreeAmount { get; set; }

    public string AvsSubNumber { get; set; } = null!;

    public string CafSubNumber { get; set; } = null!;

    public bool IsIntercantonalAgreements { get; set; }

    public virtual SalaryInsuranceName? SalaryInsuranceName { get; set; }
}
