using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AgentCommissionDetail : BaseEntity
{
    public Guid AgentCommissionId { get; set; }

    public int Priority { get; set; }

    public string ArticlesSelectionCondition { get; set; } = null!;

    public decimal Percentage { get; set; }

    public virtual AgentCommission? AgentCommission { get; set; }
}
