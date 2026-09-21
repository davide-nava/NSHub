using System;

using PlanetHub.Models;

namespace PlanetHub.ApplicationCore.Entities;

public class AgentCommissionLink : BaseEntity
{
    public Guid AgentId { get; set; }

    public Guid AgentCommissionId { get; set; }

    public virtual AgentCommission? AgentCommission { get; set; }

    public virtual Agent? Agent { get; set; }
}
