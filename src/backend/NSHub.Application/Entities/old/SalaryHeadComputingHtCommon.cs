using System;

using NSHub.Enums;
using NSHub.Models;

namespace NSHub.ApplicationCore.Entities;

public class SalaryHeadComputingHtCommon : BaseEntity
{
    public Guid SalaryHeadComputingId { get; set; }

    public Guid WorkplaceAgencyId { get; set; }

    public virtual SalaryHeadComputing? SalaryHeadComputing { get; set; }
    public virtual WorkplaceType? Workplace { get; set; }

    public WorkplaceWorkingTimeCodeType WorkplaceWorkingTimeCodeType { get; set; }

    public decimal ActivityRate { get; set; }

    public decimal WorkingTimeHours { get; set; }

    public decimal WorkingTimeLessons { get; set; }

    public WorkingTimePaymentType WorkingTimePaymentType { get; set; }

    public Guid SalaryScaleId { get; set; }

    public virtual SalaryScale? SalaryScale { get; set; }

    // TODO: Check type
    public int SalaryScaleClass { get; set; }

    // TODO: Check type
    public int SalaryScaleIncrease { get; set; }

    public DateTime SendMailDate { get; set; }

    public CivilStatusType CivilStatusType { get; set; }

    public DateTime CivilStatusDate { get; set; }

    public ResidenceCategoryType ResidenceCategoryType { get; set; }

    public ResidenceCantonType ResidenceCantonType { get; set; }

    public string ResidenceNpa { get; set; } = null!;

    public Guid DescriptionResidenceCountryId { get; set; }

    public virtual TranslationGroup? DescriptionResidenceCountry { get; set; }

    public Guid DescriptionResidenceTownId { get; set; }
    public virtual TranslationGroup? DescriptionResidenceTown { get; set; }

    public Guid DescriptionNationalityId { get; set; }

    public virtual TranslationGroup? DescriptionNationality { get; set; }
    public int NumberOfAdultChildren { get; set; }

    public int NumberOfMinorChildren { get; set; }

}
