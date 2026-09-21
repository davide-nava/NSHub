using System;

namespace PlanetHub.ApplicationCore.Entities;

public class TempDataConfiguration : BaseEntity
{
    public Guid EmployeeOnJobEntryId { get; set; }

    // TODO : Check type
    public Guid BranchId { get; set; }

    public string BranchName { get; set; } = null!;

    public string ContractNumber { get; set; } = null!;

    public string ContractName { get; set; } = null!;

    public int VersionNumber { get; set; }

    // TODO : Check type
    public Guid EditionId { get; set; }

    public string InputCriteriasSelected { get; set; } = null!;

    public string MinimumSalaryResult { get; set; } = null!;

    public Guid LanguageId { get; set; }

    public virtual Language? Language { get; set; }

    public virtual EmployeeOnJobEntry? EmployeeOnJobEntry { get; set; }
}
