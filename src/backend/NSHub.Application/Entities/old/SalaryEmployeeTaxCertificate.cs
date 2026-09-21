using System;

using PlanetHub.Enums;
using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalaryEmployeeTaxCertificate : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public int CertificateYear { get; set; }

    public CertificateType CertificateType { get; set; }

    public DateTime FromDate { get; set; }

    public DateTime ToDate { get; set; }

    public bool FreeTransport { get; set; }

    public bool CanteenLunchCheck { get; set; }

    public decimal Income { get; set; }

    public decimal FringeBenefitsFoodLodging { get; set; }

    public decimal FringeBenefitsCompanyCar { get; set; }

    public decimal FringeBenefitsOther { get; set; }

    public decimal SporadicBenefits { get; set; }

    public string SporadicBenefitsText { get; set; } = null!;

    public decimal CapitalPayment { get; set; }

    public string CapitalPaymentText { get; set; } = null!;

    public decimal OwnershipRight { get; set; }

    public decimal BoardOfDirectorsRemuneration { get; set; }

    public decimal OtherBenefits { get; set; }

    public string OtherBenefitsText { get; set; } = null!;

    public decimal Ahvalvnbuvavsacaanpcontr { get; set; }

    public decimal BvglppcontributionRegular { get; set; }

    public decimal BvglppcontributionPurchase { get; set; }

    public decimal DeductionAtSource { get; set; }

    public decimal ChargesTravelFoodAccommodation { get; set; }

    public decimal ChargesEffectiveOther { get; set; }

    public string ChargesEffectiveOtherText { get; set; } = null!;

    public decimal ChargesLumpSumRepresentation { get; set; }

    public decimal ChargesLumpSumCar { get; set; }

    public decimal ChargesLumpSumOther { get; set; }

    public string ChargesLumpSumOtherText { get; set; } = null!;

    public decimal ChargesEducation { get; set; }

    public int ProgressiveNumber { get; set; }

    public DateTime PrintDate { get; set; }

    public string FringeBenefitsOtherText { get; set; } = null!;

    public IEnumerable<TranslationGroupList> OtherFringeBenefitsTexts { get; set; }

    public bool ExpatriateExpense { get; set; }

    public bool ApprovedRegulation { get; set; }

    public Guid ApprovedRegulationCantonId { get; set; }

    public DateTime ApprovedRegulationDate { get; set; }

    public bool ConditionNm52 { get; set; }

    public bool CompanyCarClarify { get; set; }

    public bool StaffShareMarketValue { get; set; }

    public Guid StaffShareMarketValueCantonId { get; set; }

    public DateTime StaffShareMarketValueDate { get; set; }

    public IEnumerable<BoolList> StaffShareWtincomes { get; set; }

    public bool RelocationCosts { get; set; }

    public decimal RelocationCostsValue { get; set; }

    public ActivityRateType ActivityRateType { get; set; }

    public IEnumerable<StringGroupList> Remarks { get; set; }
    public IEnumerable<StringGroupList> RemarkIgmLainfcs { get; set; }


    public bool MinimalEmplCarPartPerc { get; set; }

    public bool IsSpecimen { get; set; }

    public decimal TransportMinEmplCarValue { get; set; }

    public decimal ChildAllowancePerAhv { get; set; }

    public DateTime EmailSendDate { get; set; }

    public string DocId { get; set; } = null!;

    public string OriginalDocId { get; set; } = null!;

    public Guid RecipientId { get; set; }

    public DateTime CreationDate { get; set; }

    public DateTime OriginalCreationDate { get; set; }

    public bool Ruling { get; set; }

    public Guid RulingCantonId { get; set; }

    public DateTime RulingDate { get; set; }

    public int PercentageExternalWork { get; set; }

    public int PercentageExternalWorkCanton { get; set; }

    public decimal PercentageExternalWorkValue { get; set; }

    public string BeneficiaryLastName { get; set; } = null!;

    public string BeneficiaryFirstName { get; set; } = null!;

    public string BeneficiaryNpa { get; set; } = null!;

    public string BeneficiaryTown { get; set; } = null!;

    public string BeneficiaryAddress { get; set; } = null!;

    public string BeneficiaryComplAddress { get; set; } = null!;

    public string BeneficiaryCountry { get; set; } = null!;

    public string BeneficiaryDistrict { get; set; } = null!;

    public bool TaxAtSourceForObjection { get; set; }

    public decimal TaxAtSourcePayedFromEmployer { get; set; }

    public virtual Employee? Employee { get; set; }

}
