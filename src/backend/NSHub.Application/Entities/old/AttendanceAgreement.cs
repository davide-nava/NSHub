using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AttendanceAgreement : BaseEntity
{
    public string Code { get; set; } = null!;

    public Guid DescriptionId { get; set; }

    public decimal ContractualAverage { get; set; }

    public decimal EmploymentRate { get; set; }

    public Guid AttendanceMaximalId { get; set; }

    public bool IsApplyContractualAverage { get; set; }

    public bool IsApplyEmploymentRate { get; set; }

    public bool IsShowOnHolidayTable { get; set; }

    public string WorkingCategory { get; set; } = null!;

    public string WorkingCategoryNegative { get; set; } = null!;

    public string DueWorkCategory { get; set; } = null!;

    public string DueWorkCategoryNegative { get; set; } = null!;

    public virtual TranslationGroup? Description { get; set; }
    public virtual AttendanceMaximal? AttendanceMaximal { get; set; }
}
