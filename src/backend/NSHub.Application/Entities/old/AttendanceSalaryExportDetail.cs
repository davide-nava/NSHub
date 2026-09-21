using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AttendanceSalaryExportDetail : BaseEntity
{
    public Guid AttendanceSalaryExportId { get; set; }

    public string Code { get; set; } = null!;

    public Guid AccountId { get; set; }

    public Guid AttendanceFormulaId { get; set; }

    public Guid JobFormulaId { get; set; }

    public virtual AttendanceSalaryExport? AttendanceSalaryExport { get; set; }

    public virtual Account? Account { get; set; }

    public virtual AttendanceFormula? AttendanceFormula { get; set; }

    public virtual JobFormula? JobFormula { get; set; }

    public Guid DescriptionId { get; set; }

    public virtual TranslationGroup? Description { get; set; }

}
