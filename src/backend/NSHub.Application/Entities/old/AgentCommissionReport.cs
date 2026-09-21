
namespace PlanetHub.ApplicationCore.Entities;

public class AgentCommissionReport : BaseEntity
{
    public Guid DocumentManagementId { get; set; }

    public Guid AgentId { get; set; }

    public int BulkNumber { get; set; }

    public decimal CommissionCurrency { get; set; }

    public decimal TotalCommissionCurrency { get; set; }

    public Guid LedgerBodyId { get; set; }

    public bool ToCashIn { get; set; }

    public decimal Percentage { get; set; }

    public virtual Agent? Agent { get; set; }

    public virtual DocumentManagement? DocumentManagement { get; set; }
    public virtual LedgerBody? LedgerBody { get; set; }
}
