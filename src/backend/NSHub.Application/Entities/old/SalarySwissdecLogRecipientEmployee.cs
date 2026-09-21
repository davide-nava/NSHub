using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class SalarySwissdecLogRecipientEmployee : BaseEntity
{
    public Guid RecipientId { get; set; }

    public Guid EmployeeId { get; set; }

    public bool IsUpdateExecuted { get; set; }

    public virtual Employee? Employee { get; set; }

    public virtual Recipient? Recipient { get; set; }

}
