using System.Diagnostics.Contracts;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalarySwissdecStatistic : BaseEntity
{
    public Guid EmployeeId { get; set; }

    public Guid SalarySwissdecStatisticValidityId { get; set; }

    // TODO: Check type
    public int Education { get; set; }

    public int Position { get; set; }


    public bool TemporaryAgencyWorker { get; set; }

    public bool PermanentStaffPublicAdmin { get; set; }

    public string FlexProfiling { get; set; } = null!;

    // TODO: Check type
    public int KindOfWagePayment { get; set; }

    public Guid ContractId { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Contract? Contract { get; set; }
    public Guid DescriptionJobTitleId { get; set; }

    public virtual TranslationGroup? DescriptionJobTitle { get; set; }

    public virtual SalarySwissdecStatisticValidity? SalarySwissdecStatisticValidity { get; set; }
}
