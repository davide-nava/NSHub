using System;

using NSHub.Enums;

namespace NSHub.ApplicationCore.Entities;

public class SalaryEmployeeComputingParameter : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public DateTime ValidFrom { get; set; }

    public SalaryType SalaryType { get; set; }

    public Guid WorkplaceAgencyId { get; set; }

    public string WorkplaceWorkingTimeCode { get; set; }

    public decimal WorkingTimeHours { get; set; }

    public decimal WorkingTimeLessons { get; set; }

    public WorkingTimePaymentType WorkingTimePaymentType { get; set; }

    public decimal ActivityRate { get; set; }

    public string ThirteenthCode { get; set; }

    public Guid CostCenterId { get; set; }

    public Guid SalaryAccountingHeaderId { get; set; }

    // TODO: Check type
    public int CafWorkplaceCanton { get; set; }

    public bool CompensationGrossNetSalary { get; set; }

    public bool CompensationNetSalary { get; set; }

    public bool AnnualSalary { get; set; }

    public SalaryCertificateType SalaryCertificateType { get; set; }

    public Guid IdInsuranceAvsId { get; set; }

    // TODO: Check type
    public int AvsCode { get; set; }

    // TODO: Check type
    public int AdCode { get; set; }

    public bool IsAvsSpecialCode { get; set; }

    public bool AvsSpecialCase { get; set; }

    public bool AvsWaiveOfPensionDeduct { get; set; }

    public Guid InsuranceLainfId { get; set; }

    public string InsuranceCodeLainf { get; set; } = null!;

    public IEnumerable<GuidList> InsuranceIgms { get; set; }
    public IEnumerable<GuidList> InsuranceLainfCs { get; set; }
    public IEnumerable<StringList> InsuranceCodeLainfCs { get; set; }
    public IEnumerable<StringList> InsuranceCodeIgms { get; set; }

    public IEnumerable<GuidList> InsuranceLpps { get; set; }

    public IEnumerable<StringList> InsuranceLppCategories { get; set; }
    public IEnumerable<GuidList> InsuranceLppTypes { get; set; }

    public IEnumerable<DecimalList> InsuranceLppEmployees { get; set; }
    public IEnumerable<DecimalList> InsuranceLppEmployers { get; set; }


    public Guid InsuranceCafId { get; set; }

    public bool TaxCrossborderSend { get; set; }

    public bool OldTaxCrossborder { get; set; }

    public IEnumerable<TranslationGroupList> FreeText { get; set; }


    public Guid InsuranceCpcId { get; set; }

    public Guid InsurancePeanId { get; set; }

    public decimal CpcEmployeeValue { get; set; }

    public decimal CpcEmployerValue { get; set; }

    public decimal PeanEmployeeValue { get; set; }

    public decimal PeanEmployerValue { get; set; }

    // TODO: Check type
    public int ConstantBalance { get; set; }

    public string PrintDetail { get; set; } = null!;

    public bool IsTariTemp { get; set; }

}
